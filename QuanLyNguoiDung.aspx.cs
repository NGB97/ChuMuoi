using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Spire.Doc;
using System.Drawing;
using Aspose.Words;



public partial class QuanLyNguoiDung_QuanLyNguoiDung : System.Web.UI.Page
{
   
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        string filePath = "~/Files/" + Path.GetFileName(FileUpload1.PostedFile.FileName);
        try
        {
            FileUpload1.SaveAs(Server.MapPath(filePath));
        }
        catch
        {
            Response.Write("<script>alert('Bạn chưa chọn file excel!')</script>");
            return;
        }

        string path1 = Server.MapPath(filePath);

        Aspose.Words.Document doc = new Aspose.Words.Document(path1);

        var target = path1 + "_image.doc";

          var pngTarget = Path.ChangeExtension(target, "jpg");

          doc.Save(pngTarget,SaveFormat.Jpeg);


       // object path1 = Server.MapPath(filePath);

        //       //Create word document
        //           Spire.Doc.Document document = new Spire.Doc.Document();
        //           document.LoadFromFile(path1);
        //           //Save doc file.
        //           System.Drawing.Image img = document.SaveToImages(0, Spire.Doc.Documents.ImageType.Bitmap);

        //           var target = path1 + "_image.doc";

        //           var pngTarget = Path.ChangeExtension(target, "png");
        //           //                       image.Save(pngTarget, System.Drawing.Imaging.ImageFormat.Png);
        //           img.Save(pngTarget);
        //           //Launching the image file.
        //           WordDocViewer(pngTarget);


        //   }


        //private void WordDocViewer(string fileName)
        //       {
        //           try
        //           {
        //               System.Diagnostics.Process.Start(fileName);
        //           }
        //           catch { }
        //       }

        //   //string filePath=FileUpload1.PostedFile
        ////  Server.MapPath(filePath);





        //Microsoft.Office.Interop.Word.Application myWordApp = new Microsoft.Office.Interop.Word.Application();
        //Microsoft.Office.Interop.Word.Document myWordDoc = new Microsoft.Office.Interop.Word.Document();
        //object missing = System.Type.Missing;

        //object path1 = Server.MapPath(filePath);

        //myWordDoc = myWordApp.Documents.Add(path1, missing, missing, missing);

        //foreach (Microsoft.Office.Interop.Word.Window window in myWordDoc.Windows)
        //{
        //    foreach (Microsoft.Office.Interop.Word.Pane pane in window.Panes)
        //    {
        //        for (var i = 1; i <= pane.Pages.Count; i++)
        //        {
        //            var bits = pane.Pages[i].EnhMetaFileBits;
        //            var target = path1 + "_image.doc";
        //            try
        //            {
        //                using (var ms = new MemoryStream((byte[])(bits)))
        //                {
        //                    var image = System.Drawing.Image.FromStream(ms);
        //                    var pngTarget = Path.ChangeExtension(target, "png");
        //                    image.Save(pngTarget, System.Drawing.Imaging.ImageFormat.Png);
        //                }
        //            }
        //            catch (System.Exception ex)
        //            { }
        //        }
        //    }
        //}
        //myWordDoc.Close(Type.Missing, Type.Missing, Type.Missing);
        //myWordApp.Quit(Type.Missing, Type.Missing, Type.Missing);

    }

  
}