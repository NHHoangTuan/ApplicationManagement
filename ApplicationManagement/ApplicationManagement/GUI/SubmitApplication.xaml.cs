using ApplicationManagement.BUS;
using ApplicationManagement.DTO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace ApplicationManagement.GUI
{
    /// <summary>
    /// Interaction logic for SubmitApplication.xaml
    /// </summary>
    public partial class SubmitApplication : Window
    {

        CandidateBUS candidateBUS;
        AccountBUS accountBUS;
        RecruitmentDTO recruitmentDTO;
        ApplicationBUS applicationBUS;
        RecruitmentBUS recruitmentBUS;
        BrowseProfileBUS browseProfileBUS;
        

        public SubmitApplication(RecruitmentDTO r)
        {
            InitializeComponent();

            this.DataContext = r;
            candidateBUS = new CandidateBUS();
            accountBUS = new AccountBUS();
            recruitmentDTO = (RecruitmentDTO)r.Clone();
            applicationBUS = new ApplicationBUS();
            recruitmentBUS = new RecruitmentBUS();
            browseProfileBUS = new BrowseProfileBUS();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Close();
        }


        private void upCV_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Documents (*.doc;*.docx;*.pdf)|*.doc;*.docx;*.pdf",
                Multiselect = false
            };

            if (openFileDialog.ShowDialog() == true)
            {
                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);

                if (fileInfo.Length > 5 * 1024 * 1024)
                {
                    
                    MessageBox.Show($"File vượt quá giới hạn 5MB", "Thông báo",
                   MessageBoxButton.OK);
                    return;
                }

                try
                {

                    // Define the destination path
                    string destinationDirectory = @"D:\CV_Uploaded";

                    // Ensure the directory exists
                    if (!Directory.Exists(destinationDirectory))
                    {
                        Directory.CreateDirectory(destinationDirectory);
                    }

                    // Process the file (e.g., save it to a server or directory)
                    string destinationPath = System.IO.Path.Combine(destinationDirectory, fileInfo.Name);
                    //File.Copy(fileInfo.FullName, destinationPath, true);

                    MessageBox.Show($"Upload file thành công", "Thông báo",
                   MessageBoxButton.OK);

                    nameFileUpload.Text = fileInfo.Name;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi",
                   MessageBoxButton.OK);
                }
            }
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {

            ApplicationDTO newApplication = new ApplicationDTO()
            {
                Candidate = candidateBUS.getCandidateByID(Login.CurrentAccountID),
                Position = recruitmentDTO.Vacancies,
                Validity = "NOT OK",

            };

            if (newApplication != null)
            {
                try
                {

                    int applicationID = 0;
                    int advertiseFormID = 0;
                    try
                    {
                        applicationID = applicationBUS.addApplication(newApplication);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi",
                       MessageBoxButton.OK);
                    }

                    try
                    {
                        advertiseFormID = recruitmentBUS.getAdvertiseByRecruitFormID(recruitmentDTO.formID);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi",
                       MessageBoxButton.OK);
                    }


                    try
                    {
                        browseProfileBUS.insertBrowseProfile(advertiseFormID, applicationID, DateTime.Now);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi",
                       MessageBoxButton.OK);
                    }

                    
                    MessageBox.Show("Nộp hồ sơ ứng tuyển thành công", "Thông báo",
                   MessageBoxButton.OK);
                    Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Lỗi",
                   MessageBoxButton.OK);
                }
                
            }

        }
    }
}
