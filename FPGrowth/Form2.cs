using FPGrowth.Algorithm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FPGrowth
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            guide.Text = "       Bước đầu tiên trong quá trình thực thi thuật toán là chọn cơ sở dữ liệu. Ở bước này, người dùng được phép chọn cơ sở dữ liệu mong muốn để thực thi thuật toán. \r\n\r\n" +
            "       Bước 2: Nhập giá trị minSup cho thuật toán, thuật toán chỉ hoạt động khi minSup trong khoảng giá trị [0, 100], ngoài khoảng này minSup tự động đưa giá trị trong ô về rỗng và người dùng phải nhập lại từ đầu. Tương tự, ô minConf cũng được đảm bảo giá trị bằng cách này. " +
            "minSup là giá trị giúp tính toán độ phổ biến tối thiểu(minSupCount). Độ phổ biến tối thiểu là một số nguyên dương thể hiện số lần xuất hiện tối thiểu phải đạt của một item, xét trong tất cả các giao dịch. \r\n" +
            "                                            Ta có: minSupCount = minSup / 100 * số giao dịch \r\n\r\n" +
            "       Bước 3: Nhập giá trị minConf, giá trị này không thuộc phạm vi thuật toán FP Growth nhưng nó lại mang ý nghĩa trong việc tìm ra các luật kết hợp mạnh. Luật kết hợp mạnh là các luật mà trong trường hợp của nó, giá trị conf ≥ minConf. \r\n\r\n" +
            "       Bước 4: Chọn nút THỰC THI để thực thi thuật toán, kết quả của thuật toán FP Growth được thể hiện hoàn toàn ở bước này, đó là tìm ra tất cả những ItemSet phổ biến. Bộ ItemSet đó là tiền đề để ta tiếp tục tìm ra các luật kết hợp mạnh.\r\n\r\n" +
            "       Bước 5: Chọn nút TÌM LUẬT để tìm ra các luật kết hợp mạnh. Nút này chỉ có thể được thực hiện nếu như ta đã có các bộ ItemSet phổ biến, tức là nút TÌM LUẬT phải được nhấn sau khi nhấn nút THỰC THI. Đối với 2 khung kết quả sinh ra từ nút lệnh này, bao gồm các phép tính để tính conf và kết quả sinh các luật kết hợp mạnh, dữ liệu sẽ thay đổi tự động theo giá trị của ô minConf. Ngoài ra, khi ta thay đổi giá trị ô minSup hay thay đổi cơ sở dữ liệu, dữ liệu trong các ô kết quả sẽ đặt lại trạng thái ban đầu và chờ kết quả mới.\r\n\r\n";
        }
        static List<List<T>> GetSubsets<T>(IEnumerable<T> Set)
        {
            var set = Set.ToList<T>();
            // Init list
            List<List<T>> subsets = new List<List<T>>();
            for (int i = 1; i < set.Count; i++)
            {
                subsets.Add(new List<T>() { set[i - 1] });
                List<List<T>> newSubsets = new List<List<T>>();
                // Loop over existing subsets
                for (int j = 0; j < subsets.Count; j++)
                {
                    var newSubset = new List<T>();
                    foreach (var temp in subsets[j])
                        newSubset.Add(temp);
                    newSubset.Add(set[i]);
                    newSubsets.Add(newSubset);
                }
                subsets.AddRange(newSubsets);
            }
            // Add in the last element
            subsets.Add(new List<T>() { set[set.Count - 1] });
            foreach (List<T> l in subsets)
            {
                if (l.Count == set.Count)
                {
                    subsets.Remove(l);
                    break;
                }
            }
            return subsets;
        }
    }
}
