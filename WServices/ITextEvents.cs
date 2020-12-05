using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace System.Data.Common
{
    public class ITextEvents : PdfPageEventHelper
    {
        #region define property for dynamic Fields
        private bool _headerRequired;
        private bool _footerRequired;
        private bool _pageRequired;
        private bool _borderRequired;
        private string _headerText;
        private string _footerText;
        private string _logopath;
        private string _PaperSize;
        #endregion

        #region get set Properties
        public bool HeaderRequired
        {
            get { return _headerRequired; }
            set { _headerRequired = value; }
        }
        public bool FooterRequired
        {
            get { return _footerRequired; }
            set { _footerRequired = value; }
        }
        public bool PageRequired
        {
            get { return _pageRequired; }
            set { _pageRequired = value; }
        }
        public bool BorderRequired
        {
            get { return _borderRequired; }
            set { _borderRequired = value; }
        }
        public string HeaderText
        {
            get { return _headerText; }
            set { _headerText = value; }
        }
        public string FooterText
        {
            get { return _footerText; }
            set { _footerText = value; }
        }
        public string LogoPath
        {
            get { return _logopath; }
            set { _logopath = value; }
        }
        public string PaperSize
        {
            get { return _PaperSize; }
            set { _PaperSize = value; }
        }
        #endregion

        public ITextEvents(bool headerRequired, bool footerRequired, bool pageRequired, bool borderRequired, string headerText, string footerText, string logopath, string Papertype)
        {
            HeaderRequired = headerRequired;
            FooterRequired = footerRequired;
            PageRequired = pageRequired;
            BorderRequired = borderRequired;
            HeaderText = headerText;
            FooterText = footerText;
            LogoPath = logopath;
            PaperSize = Papertype;
        }
        // This is the contentbyte object of the writer
        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate headerTemplate, footerTemplate;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;



        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                headerTemplate = cb.CreateTemplate(100, 100);
                footerTemplate = cb.CreateTemplate(50, 50);
            }
            catch (DocumentException de)
            {
                //handle exception here
            }
            catch (System.IO.IOException ioe)
            {
                //handle exception here
            }
        }

        public Image SignatureCert(Image logo)
        {
            //TODO: You will want to change the logo image here.  
            Image gif = logo;
            // This scales the image to a usable size.  you can change this if your image does not look right.
            gif.ScaleAbsolute(105.0f, 10.0f);
            return gif;
        }
        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {
            base.OnEndPage(writer, document);

            iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            Phrase p1Header = new Phrase(null, null);
            //removing Header HTML COntent
            if (HeaderText != null)
            {
                FontFactory.RegisterDirectories();
                List<IElement> htmlarraylist = HTMLWorker.ParseToList(new StringReader(HeaderText), null);
                for (int k = 0; k < htmlarraylist.Count; k++)
                {
                    p1Header.Add((IElement)htmlarraylist[k]);
                }
            }

            Phrase p1Footer = new Phrase(null, null);
            //removing Footer HTML COntent
            if (FooterText != null)
            {
                FontFactory.RegisterDirectories();
                List<IElement> htmlarrayFooterlist = HTMLWorker.ParseToList(new StringReader(FooterText), null);
                for (int m = 0; m < htmlarrayFooterlist.Count; m++)
                {
                    p1Footer.Add((IElement)htmlarrayFooterlist[m]);
                }
            }
            //Create PdfTable object
            PdfPTable pdfTab = new PdfPTable(3);          
            pdfTab.WidthPercentage = 90;

            float[] tblDescWidth52 = new float[3];
            tblDescWidth52[0] = 25;
            tblDescWidth52[1] = 72;
            tblDescWidth52[2] = 2;

            pdfTab.SetWidths(tblDescWidth52);
            String text = "Page " + writer.PageNumber + " of ";
            //We will have to create separate cells to include image logo and 2 separate strings
            //Row 1
            if (HeaderRequired)
            {
                PdfPCell pdfCell1 = new PdfPCell();
                PdfPCell pdfCell2 = new PdfPCell(p1Header);
                PdfPCell pdfCell3 = new PdfPCell();

                //  iTextSharp.text.Image imgLogo = iTextSharp.text.Image.GetInstance(HttpContext.Current.Server.MapPath("~/Images/customer Images/ReportLogo/" + LogoPath));

                //  iTextSharp.text.Image imgLogo = iTextSharp.text.Image.GetInstance("F:/MAIN V10/Sharda_Hospital/Sharda_12_08_2016/WinApps/ReportLogo/Win7645logo3.PNG");

                //  imgLogo.ScaleToFit(80, 60);
                //  pdfCell1.AddElement(imgLogo);

                string base64Image = LogoPath;                       // new 18-08 
                Regex regex = new Regex(@"^data:image/(?<mediaType>[^;]+);base64,(?<data>.*)");    // new 18-08 
                Match match = regex.Match(base64Image);   // new 18-08 

                Image image = Image.GetInstance(      // new 18-08 
              Convert.FromBase64String(match.Groups["data"].Value)    // new 18-08 
          );

                image.ScaleToFit(80, 60);   // new 18-08 
                pdfCell1.AddElement(image);    // new 18-08 


                //Row 2
                PdfPCell pdfCell4 = new PdfPCell(new Phrase(null, baseFontNormal));
                //Row 3

                //set the alignment of all three cells and set border to 0
                pdfCell1.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell2.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfCell4.HorizontalAlignment = Element.ALIGN_CENTER;

                pdfCell2.VerticalAlignment = Element.ALIGN_CENTER;
                pdfCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfCell4.VerticalAlignment = Element.ALIGN_TOP;

                pdfCell4.Colspan = 3;

                pdfCell1.Border = 0;
                pdfCell2.Border = 0;
                pdfCell3.Border = 0;
                pdfCell4.Border = 0;

                //add all three cells into PdfTable
                pdfTab.AddCell(pdfCell1);
                pdfTab.AddCell(pdfCell2);
                pdfTab.AddCell(pdfCell3);
                pdfTab.AddCell(pdfCell4);

                pdfTab.TotalWidth = document.PageSize.Width - 80f;
                pdfTab.WidthPercentage = 70;

                //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
                //first param is start row. -1 indicates there is no end row and all the rows to be included to write
                //Third and fourth param is x and y position to start writing
                pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, writer.DirectContent);

                //Move the pointer and draw line to separate header section from rest of page
                if (BorderRequired)
                {
                    cb.MoveTo(40, document.PageSize.Height - 100);
                    cb.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 100);
                    cb.Stroke();
                }
            }
            //footer code
            if (FooterRequired)
            {
                //Move the pointer and draw line to separate footer section from rest of page
                if (BorderRequired)
                {
                    cb.MoveTo(40, document.PageSize.GetBottom(50));
                    cb.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(50));
                    cb.Stroke();
                }

                //Add Footer text to footer
                PdfPTable pdfTaba = new PdfPTable(1);
               
                               

                PdfPCell pdfCellfooter = new PdfPCell(p1Footer);

                pdfCellfooter.HorizontalAlignment = Element.ALIGN_LEFT;
                pdfCellfooter.Border = 0;
                pdfCellfooter.VerticalAlignment = Element.ALIGN_BOTTOM;
                if (PaperSize=="")
                {
                    pdfTaba.TotalWidth = document.PageSize.Width - 80f;
                }
                else
                {
                    pdfTaba.TotalWidth = document.PageSize.Width;
                }
                
                pdfTaba.WidthPercentage = 100;

                pdfTaba.AddCell(pdfCellfooter);
                //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
                //first param is start row. -1 indicates there is no end row and all the rows to be included to write
                //Third and fourth param is x and y position to start writing
               // pdfTaba.WriteSelectedRows(0, -1, document.PageSize.GetRight(550), document.PageSize.GetBottom(50), writer.DirectContent);
                if (PaperSize == "A4 Size")
                    pdfTaba.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 750, writer.DirectContent);
                else
                {
                    pdfTaba.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 500, writer.DirectContent);
                }

            }
            if (PageRequired)
            {
                //Add paging to footer
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(document.PageSize.GetRight(120), document.PageSize.GetBottom(35));
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 12);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(120) + len, document.PageSize.GetBottom(35));
            }
            if (BorderRequired)
            {
                //Add Paging to Border
                var content = writer.DirectContent;
                var pageBorderRect = new Rectangle(document.PageSize);

                pageBorderRect.Left += 40f;
                pageBorderRect.Right -= 40f;
                pageBorderRect.Top -= 30f;
                pageBorderRect.Bottom += 30f;

                content.SetColorStroke(BaseColor.BLACK);
                content.Rectangle(pageBorderRect.Left, pageBorderRect.Bottom, pageBorderRect.Width, pageBorderRect.Height);
                content.Stroke();
            }

        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);

            headerTemplate.BeginText();
            headerTemplate.SetFontAndSize(bf, 12);
            headerTemplate.SetTextMatrix(0, 0);
            headerTemplate.ShowText((writer.PageNumber).ToString());
            headerTemplate.EndText();

            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 12);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber).ToString());
            footerTemplate.EndText();


        }
    }
}
