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

        private string uploadedCVPath = "";


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

        private string SaveFileToCandidateFolder(string sourceFilePath, string candidateID)
        {
            try
            {
                // Define the destination directory with candidate ID
                string candidateDirectory = System.IO.Path.Combine(@"D:\App\CV_Uploaded", candidateID);

                // Ensure the directory exists
                if (!Directory.Exists(candidateDirectory))
                {
                    Directory.CreateDirectory(candidateDirectory);
                }

                // Get the file name
                string fileName = System.IO.Path.GetFileName(sourceFilePath);

                // Define the destination path
                string destinationPath = System.IO.Path.Combine(candidateDirectory, fileName);

                // Copy the file to the destination path
                File.Copy(sourceFilePath, destinationPath, true);

                // Return the destination path
                return destinationPath;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButton.OK);
                return null;
            }
        }



        private void upCV_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Documents (*.pdf)|*.pdf",
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

                    string candidateID = Login.CurrentAccountID; // Lấy ID của ứng viên

                    // Save file to candidate's folder
                    string destinationPath = SaveFileToCandidateFolder(fileInfo.FullName, candidateID);

                    if (destinationPath != null)
                    {
                        MessageBox.Show($"Upload file thành công", "Thông báo", MessageBoxButton.OK);

                        nameFileUpload.Text = fileInfo.Name;
                        uploadedCVPath = destinationPath; // Lưu đường dẫn file CV đã tải lên
                    }

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
                CVPath= uploadedCVPath,

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


                    try
                    {
                        applicationBUS.updateCVPath(applicationID, newApplication.CVPath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Lỗi",
                       MessageBoxButton.OK);
                    }


                    MessageBox.Show("Nộp hồ sơ ứng tuyển thành công", "Thông báo",
                   MessageBoxButton.OK);
                    DialogResult = true;
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
