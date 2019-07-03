using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using iTextSharp.text;

using iTextSharp.text.html.simpleparser;

using iTextSharp.text.pdf;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //string HTMLContent = "Hello <b>World</b>";

        //Response.Clear();
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=" + "PDFfile.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //Response.BinaryWrite(GetPDF(HTMLContent));
        //Response.End();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        System.IO.StringWriter stringWrite = new System.IO.StringWriter();
        string fileName = " EmployeeTranferReport.pdf";
        Response.AppendHeader("Content-Type", "application/pdf");
        Response.AppendHeader("Content-disposition", "attachment; filename=" + fileName);
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        stringWrite.WriteLine("<html><body encoding=" + BaseFont.IDENTITY_H + " style='font-family:Arial Unicode MS;font-size:12;'> <table style='width:100%'><tr><td align='center'><b>Vãi nồi</b></td></tr><tr><td align='center'>अगरतला</td></tr></table> </body></html>");

        HtmlTextWriter hw = new HtmlTextWriter(stringWrite);
        StringReader sr = new StringReader(stringWrite.ToString());
        Document pdfDoc = new Document(PageSize.A4, 20f, 10f, 10f, 0f);
        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter wi = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();

        string fontpath = Environment.GetFolderPath(Environment.SpecialFolder.Fonts) + "\\ARIALUNI.TTF";        //  "ARIALUNI.TTF" file copied from fonts folder and placed in the folder

        BaseFont bf = BaseFont.CreateFont(fontpath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
        FontFactory.RegisterDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), true);
        FontFactory.Register(fontpath, "Arial Unicode MS");
        //FontFactory.RegisterFamily("Arial Unicode MS", "Arial Unicode MS", fontpath);
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
    public void DownloadAsPDF()
    {
        try
        {
            string strHtml = string.Empty;
            string pdfFileName = "GenerateHTMLTOPDF.pdf";
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            //dvHtml.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            strHtml = sr.ReadToEnd();
            sr.Close();

            CreatePDFFromHTMLFile("<div style='font-family:arial unicode ms;'>" + strHtml + "</div>", pdfFileName);

            Response.ContentType = "application/x-download";
            Response.AddHeader("Content-Disposition", string.Format("attachment; filename=\"{0}\"", "GenerateHTMLTOPDF.pdf"));
            Response.ContentEncoding = Encoding.UTF8;
            Response.WriteFile(pdfFileName);
            Response.HeaderEncoding = Encoding.UTF8;
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    private void CreatePDFFromHTMLFile(string html, string FileName)
    {
        TextReader reader = new StringReader(html);
        // step 1: creation of a document-object
        Document document = new Document(PageSize.A4, 30, 30, 30, 30);

        // step 2:
        // we create a writer that listens to the document
        // and directs a XML-stream to a file
        PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(FileName, FileMode.Create));

        // step 3: we create a worker parse the document
        HTMLWorker worker = new HTMLWorker(document);

        // step 4: we open document and start the worker on the document
        document.Open();

        // step 4.1: register a unicode font and assign it an allias
        FontFactory.Register(@"..\Fonts\\ARIALUNI.TTF", "arial unicode ms");

        // step 4.2: create a style sheet and set the encoding to Identity-H
        iTextSharp.text.html.simpleparser.StyleSheet ST = new iTextSharp.text.html.simpleparser.StyleSheet();
        ST.LoadTagStyle("body", "encoding", "Identity-H");

        // step 4.3: assign the style sheet to the html parser
        worker.Style = ST;

        worker.StartDocument();

        // step 5: parse the html into the document
        worker.Parse(reader);

        // step 6: close the document and the worker
        worker.EndDocument();
        worker.Close();
        document.Close();
    }
}