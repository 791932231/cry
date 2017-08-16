using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing;
using System.Data;
using System.Text;
using System.ComponentModel;


namespace Login
{
    public partial class loginTest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                changeTheIamge();
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        string _s = string.Empty;
        /// <summary>
        /// 创建验证码图片
        /// </summary>
        private void changeTheIamge()
        {
            Bitmap img = new Bitmap(70, 30);//新建图片
            Graphics g = Graphics.FromImage(img);

            g.Clear(Color.White);//设置背景图片

            _s = this.RandomString();//调用产生随机数的方法，用成员变量接收
            Session["session_s"] = _s;
            Color c = this.RandomColor();//调用产生背景色的方法  并接收
            g.DrawString(_s, new Font("宋体", 20), new SolidBrush(c), 5, 0);//字体的大小 颜色 位置

            //绘制干扰线
            for (int i = 0; i < 5; i++)
            {
                Random random = new Random(Convert.ToInt32(Guid.NewGuid().GetHashCode()));//Guid类  哈希代码???

                Pen pen = new Pen(this.RandomColor());//Pen 用于绘制曲线和直线  这里调用了设置背景颜色的方法

                g.DrawLine(pen, 10, random.Next(0, 25), 80, random.Next(2, 40));//绘制一天连接坐标指定俩点的直线
            }
            g.Dispose();//释放 ..  资源？？？
            var fileUrl = "~/Content/label_1.bmp";
                string file = System.Web.HttpContext.Current.Server.MapPath(fileUrl);
            if (System.IO.File.Exists(file))
            {
                System.IO.File.Delete(file);
            }
            img.Save(System.Web.HttpContext.Current.Server.MapPath("~/Content/label_1.bmp"), ImageFormat.Bmp);
            this.Image1.ImageUrl = "~/Content/label_1.bmp";
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            var name = this.TextBox1.Text;
            var password = this.TextBox2.Text;
            if (name == "admin" && password == "admin")
            {
                string Text = this.TextBox3.Text.ToUpper();
                if (Text == Session["session_s"].ToString())
                {
                    this.Label1.Text = "登陆成功";
                }
                else
                {
                    this.Label1.Text = "验证码有误";
                }
            }
            else
            {
                this.Label1.Text = "用户名或者密码有误";
            }
        }
        private Color RandomColor()
        {
            Random random = new Random(Convert.ToInt32(Guid.NewGuid().GetHashCode()));

            Color c = Color.FromArgb(255, random.Next(0, 100), random.Next(0, 100), random.Next(0, 100));

            return c;//返回背景颜色
        }


        /// <summary>
        /// 产生四位随机数
        /// </summary>
        /// <returns></returns>
        private string RandomString()
        {
            string allchars = "0123456789abcdefghijklmnopqrstuvwxyz";
            string ranchars = string.Empty;
            for (int i = 0; i < 4; i++)
            {
                Random random = new Random(Convert.ToInt32(Guid.NewGuid().GetHashCode()));
                int num = random.Next(0, 36);//返回指定范围内的随机数 0 - 36 ？？
                ranchars += allchars[num].ToString();//...
            }
            return ranchars.ToUpper();//返回 随机数
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.changeTheIamge();
        }
    }
}