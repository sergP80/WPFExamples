using SharedResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileBrowser.ViewModel
{
    public class MainViewModel: AbstractObservableViewModel
    {
        public MainViewModel()
        {
            LeftContent = new TreeViewModel<FolderTreeItem>();
            InitLeftContent();
        }

        public TreeViewModel<FolderTreeItem> LeftContent { get; private set; }

        private void InitLeftContent()
        {
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (var driveInfo in drives)
            {
                LeftContent.Add(
                    new FolderTreeItem(
                        driveInfo.Name, 
                        driveInfo.DriveType == System.IO.DriveType.Fixed,
                        driveInfo.DriveType == System.IO.DriveType.Removable,
                        driveInfo.DriveType == System.IO.DriveType.CDRom
                    )
                );
            }
        }

    }
}
