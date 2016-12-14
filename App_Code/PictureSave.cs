using System;
using System.IO;
using System.Web;

/// <summary>
/// Summary description for PictureSave
/// </summary>
public class PictureSave
{
    //public static string SavePicture(FileUpload FU, string GemHer, int Str)
    public static string SavePicture(HttpPostedFile FU, string GemHer, int Str)
    { 
            //hest_2013081212.jpg
            string NytFilNavn = Path.GetFileNameWithoutExtension(FU.FileName)+ Path.GetExtension(FU.FileName);
            return PictureSave.SavePicture(FU, GemHer, Str, NytFilNavn);
    }


    //public static string SavePicture(FileUpload FU, string GemHer, int Str, string NytFilNavn )
    public static string SavePicture(HttpPostedFile FU, string GemHer, int Str, string NytFilNavn)
    {
        // Eks. GemmesHer går fra eks. /gfx/big til C:\Marianne\asp.net\_CSHARP\Soda-Marianne\gfx/big
        string extension = Path.GetExtension(FU.FileName).ToLower(); //.jpg

        if (extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".png")
        {
            try
            {
                String TempImage;
                String NytImage;

                // TEMPIMAGE - arbejdsfilen - prefikses med _temp_, gemmes i mappen hvor det færdige billede skal gemmes, og bliver gjort til streamin for nye billede
                TempImage = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, GemHer) + "_temp_" + NytFilNavn;
                FU.SaveAs(TempImage);
                StreamReader StreamIn = new StreamReader(TempImage);
                // NYTIMAGE - måske flere placeringer - måske flere størrelser
                NytImage = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, GemHer) + NytFilNavn;
                StreamWriter StreamOut = new StreamWriter(NytImage);
                imageResize.ResizeImage(Str, StreamIn.BaseStream, StreamOut.BaseStream);
                // LUK streams og slet TEMP-billede
                StreamOut.Close();
                StreamIn.Close();

                //for at sætte flere billeder af det samme billede som StreamOut men bare i et anden støresle gør:

                //Ny resize
                //StreamReader streamIn2 = new StreamReader(TempImage);
                //StreamWriter streamOut2 = new StreamWriter(NytImage);
                //Resizer til bredde 100px
                //imageResize.ResizeImage(100, streamIn2.BaseStream, streamOut2.BaseStream);

                //streamIn2.Close();
                //streamOut2.Close();
                //------------------------------------------------------------------------------------------------

                IOFunctions.DeleteFile(TempImage);
            }
            catch (Exception)
            {
                throw;
            }
        }
        else
        {
            NytFilNavn = "fotopaavej.jpg";
        }
        return NytFilNavn;
    }
}