using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SilverlightApplication.MPartServiceReference;

namespace SilverlightApplication
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
         
        }

       
        private void GetMPartSearch_Click(object sender, RoutedEventArgs e)
        {
            MPartParamDTO inputDTO = new MPartParamDTO();
            inputDTO.MPartNumber = txtGetMPartSearch.Text.Trim();
            inputDTO.PageIndex = 1;

            MPartServiceClient proxy = new MPartServiceClient(); 
            proxy.GetMPartSearchCompleted += new EventHandler<GetMPartSearchCompletedEventArgs>(proxy_GetMPartSearchCompleted);
            proxy.GetMPartSearchAsync(inputDTO);
        }
        void proxy_GetMPartSearchCompleted(object sender, GetMPartSearchCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                MPartResultDTO result = e.Result;
                var list = result.MPartList;
                MessageBox.Show(result.TotalCount.ToString());
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
        }

        private void ReturnExceptionSearch_Click(object sender, RoutedEventArgs e)
        {
            MPartServiceClient proxy = new MPartServiceClient();
            proxy.ReturnExceptionSearchCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(proxy_ReturnExceptionSearchCompleted);
            proxy.ReturnExceptionSearchAsync();
        }

        void proxy_ReturnExceptionSearchCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
            { 
                MessageBox.Show("无异常");
            }
            else
            {
                MessageBox.Show(e.Error.Message);
            }
        }
    }
}
