using log4net;
using System;
using System.Web;
using WebCamApplication.Models;

namespace WebCamApplication.Common
{
    public class Save
    {
        private static log4net.ILog Log { get; set; }
        ILog log = log4net.LogManager.GetLogger(typeof(Save));
       
        public bool SaveToThePage(DrawingModel model, System.Web.HttpContext hc)
        {
           
         
            try
            {

                byte[] data = Convert.FromBase64String(model.imageData);
                hc.Response.ContentType = "image/png";
            
            hc.Response.ContentType = "application/vnd.ms-excel";
            hc.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}PostCard.png", model.UserName));
            hc.Response.OutputStream.Write(data, 0, data.Length);
            hc.Response.OutputStream.Flush();
            hc.Response.End();
            return true;
            }
            catch (Exception e)
            {

                log.Error(e);
                return false;
            }
            finally
            {
                
            }
        }

       
    }
}