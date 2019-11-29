### 创建一个依赖属性

```xaml
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace DependencyPropertyDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void testBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.CustonBtn.Space.ToString());
            this.CustonBtn.Space = 5;
        }
    }

    /// <summary>
    /// 1. 能含有依赖属性的类必须继承DependenceObject
    /// 2. 输入propdp，按两次Tab即可快速生成依赖属性
    /// 3. 依赖属性和普通CLR属性的区别：
    ///     当我们想要知道某个对象的CLR属性值时，直接去heap中的Field存储单元获得；
    ///     在WPF中，依赖属性并没有back field，无法从某个存储空间读取，而是临时按照规则查找或计算得来，
    ///     这也是WPF框架本身的性能瓶颈。依赖属性的优点是节省内存，因为不需要内存存储属性值。
    ///  4.依赖属性是DependenceProperty类型，这个类，
    ///  5.我们为每个依赖属性提供一个CLR包装属性，这样依赖属性就具备了作为数据源的能力，能够双向绑定。
    ///  6.调用new函数生成一个WPF依赖对象（控件）时，并不会在heap中生成字段，当我们需要知道对象的属性时，
    ///     实时计算得出。
    /// </summary>
    public class CustomButton : Button
    {
        public int Space
        {
            get { return (int)GetValue(SpaceProperty); }
            set { SetValue(SpaceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SpaceProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SpaceProperty =
            DependencyProperty.Register("Space",//CLR属性名称，一般把依赖属性名字去掉Propriety即可
                typeof(int),//类型
                typeof(CustomButton), //依赖属性的宿主
                //依赖属性的默认值          属性值改变时，伴随着发生什么
                new PropertyMetadata { DefaultValue = 2, PropertyChangedCallback = SpacePropertyChangedCallback},
                ValidateSpaceValue //对赋给依赖属性值的合理性进行校验，不合理WPF平台会抛出异常
                );
        public static void SpacePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CustomButton cb = d as CustomButton;
            string txt = cb.Content as string;
            if(txt == null)
            {
                return;
            }
            cb.Content = cb.SpaceOutTxt(txt);
        }
        /// <summary>
        /// 校验赋给依赖属性的值的合理性
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool ValidateSpaceValue(object obj)
        {
            int value = (int)obj;
            return value >= 0;
        }
        private string SpaceOutTxt(string rawTxt)
        {
            if(rawTxt == null)
            {
                return rawTxt;
            }

            StringBuilder sb = new StringBuilder();
            foreach (var item in rawTxt)
            {
                sb.Append(item + new string(' ',Space));
            }
            return sb.ToString();
        }
    }
}

```

### 依赖属性值来源的优先级

1. 动画
2. 直接显示为属性赋值，如Background = "Red";以及数据绑定
3. 模板
4. 样式触发器
5. 样式触发器
6. 样式
7. 属性值继承
8. 元数据的默认值