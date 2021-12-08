using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Calendar
{
    public class Controller
    {
        private static readonly string filePath = Application.StartupPath + "\\data.xml";

        // Ghi nội dung vào file
        public static bool SerializeToXML(object data)
        {
            FileStream fs = null;
            try
            {
                fs = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                XmlSerializer xml = new XmlSerializer(typeof(PlanData));

                xml.Serialize(fs, data);
                return true;
            }
            catch (IOException)
            {
                MessageBox.Show("Không thể ghi nội dung vào file data.xml " +
                    "do file đang được sử dụng bởi một tiến trình hoặc chương trình khác!",
                    "Error: Cannot Access File!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (UnauthorizedAccessException e)
            {
                MessageBox.Show(string.Format("Truy cập vào đường dẫn {0} để lưu file data.xml bị từ chối!", filePath),
                    "Error: " + e.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi không xác định!", "Error: An Unknown Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }
            }
            return false;
        }

        // Đọc nội dung từ file
        public static object DeserializeFromXML()
        {
            FileStream fs = null;
            object obj = null;
            DialogResult choice = DialogResult.OK;

            try
            {
                fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                XmlSerializer xml = new XmlSerializer(typeof(PlanData));

                obj = xml.Deserialize(fs);
            }
            catch (FileNotFoundException)
            {
                choice = MessageBox.Show("Không tìm thấy file data.xml!\n\n" +
                    "Bạn vẫn muốn tiếp tục?",
                    "Error: File Not Found!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (InvalidOperationException)
            {
                choice = MessageBox.Show("Nội dung file data.xml không hợp lệ!\n\n" +
                    "Bạn vẫn muốn tiếp tục?",
                    "Error: File has invalid content!", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                choice = MessageBox.Show("Lỗi không xác định!\n\n" +
                    "Bạn vẫn muốn tiếp tục?", "Error: An Unknown Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (fs != null)
                {
                    fs.Close();
                }

                if (choice == DialogResult.Cancel)
                {
                    Environment.Exit(0);
                }
            }
            return obj;
        }

    }
}
