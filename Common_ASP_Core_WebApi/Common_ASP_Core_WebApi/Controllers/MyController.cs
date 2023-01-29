using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;

namespace Common_ASP_Core_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyController : ControllerBase
    {
        // [Route]              // RouteAttribute
        [HttpPost("Init")]
        public string[][] ABCD()
        {
            bool isgameover_lab = false;
            int[] arr = new int[15];
            int i, j, k = 0;
            for (i = 0; i < 15; i++)
            {
                arr[i] = i + 1;
            }
            Random myRand = new Random();
            for (i = 14; i > 0; i--)
            {
                int R = myRand.Next(i);
                int temp1 = arr[i];
                arr[i] = arr[R];
                arr[R] = temp1;
            }
            string[][] Buttons_res = new string[15][];
            for (int f = 0 ; f < 15; f++)
            {
                Buttons_res[f] = new string[2];
            }

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    if (k != 15)
                    {
                        Color color = Color.FromArgb(myRand.Next(100, 255), myRand.Next(100, 255), myRand.Next(100, 255));
                        string color_res = color.R + "," + color.G + ","+ color.B;
                        string number = arr[k].ToString();
                        Buttons_res[i * 4 + j][0] = color_res;
                        Buttons_res[i * 4 + j][1] = number;
                        k++;
                    }
                }
            }
            return Buttons_res;
            
        }
     
        [HttpPost("next_step")]       // HttpPostAttribute
        public string ABCD(Buttons_type myreq)
        {
            int indRow = int.Parse(myreq.indRow);
            int indCol = int.Parse(myreq.indCol);
            int indRowEmpty = int.Parse(myreq.indRowEmpty);
            int indColEmpty = int.Parse(myreq.indColEmpty);
            string res = "";
            if ((Math.Abs(indRow - indRowEmpty) + Math.Abs(indCol - indColEmpty)) == 1)
            {
                if (indRow == indRowEmpty && indCol + 1 == indColEmpty)
                {
                    res = "Right";
                }
                else if (indRow + 1 == indRowEmpty && indCol == indColEmpty)
                {
                    res = "Down";
                }
                else if (indRow == indRowEmpty + 1 && indCol == indColEmpty)
                {
                    res = "Up";
                }
                else if (indRow == indRowEmpty && indCol == indColEmpty + 1)
                {
                    res = "Left";
                }
            }
            return res;
        }
    }
}
