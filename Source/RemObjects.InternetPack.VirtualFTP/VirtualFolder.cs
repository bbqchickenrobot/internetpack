using System;
using System.IO;
using System.Collections;

namespace RemObjects.InternetPack.Ftp.VirtualFtp
{

  public class VirtualFolder : FtpFolder
	{
		public VirtualFolder(IFtpFolder aParent, string aName) : this(aParent, aName, "system", "system", false)
		{
      fFileList = new Hashtable();
      WorldRead = true;
      WorldWrite = false;
      Date = DateTime.Now;
    }

    public VirtualFolder(IFtpFolder aParent, string aName, string aOwningUser, string aOwningGroup, bool aWorldWritable) : base(aParent, aName)
    {
      fFileList = new Hashtable();
      WorldRead = true;
      WorldWrite = aWorldWritable;
      OwningUser = aOwningUser;
      OwningGroup = aOwningGroup;
      Date = DateTime.Now;
    }

    #region Elements
    private Hashtable fFileList;

    public override IEnumerable SubFolders 
    {
      lock (this)
      {
        if (aItem is IFtpFolder)
        {
          aItem.Parent = this;
          SubFolderList.Add(aItem.Name.ToLower(), aItem);
        }
        else if (aItem is IFtpFile)
        {
          aItem.Parent = this;
          FileList.Add(aItem.Name.ToLower(), aItem);
        }
      }
    }

        throw new FtpException(550, String.Format("Cannot access folder \"{0}\", permission to access items in this folder denied.",aFolderName));
        throw new FtpException(550, String.Format("Cannot access folder \"{0}\", permission to browse folder denied.",aFolderName));
        throw new FtpException(String.Format("A file named \"{0}\" does not exists.",aFilename));
        throw new FtpException(550,String.Format("Cannot access file \"{0}\", permission to access files in this folder denied.",aFilename));
        throw new FtpException(550, String.Format("Cannot access file \"{0}\", permission to access file denied.",aFilename));
    #region Create*
    public override sealed IFtpFolder CreateFolder(string aFolderName, VirtualFtpSession aSession)
        throw new FtpException(550, String.Format("Cannot create folder \"{0}\", permission to mkdir in this folder denied.",aFolderName));
        throw new FtpException(550, String.Format("Cannot create file \"{0}\", permission to upload to this folder denied.",aFilename));
    #endregion

    #region Create* virtuals
    protected virtual IFtpFolder DoCreateFolder(string aFolderName, VirtualFtpSession aSession)
    #region Delete*
    public override void DeleteFolder(string aFolderName, bool aRecursive, VirtualFtpSession aSession)
        throw new FtpException(String.Format("A folder named \"{0}\" does not exists.",aFolderName));
      if (!AllowDeleteItems(aSession))
        throw new FtpException(550, String.Format("Cannot delete folder \"{0}\", permission to delete from this folder denied.",aFolderName));
      IFtpFolder lFolder = GetSubFolder(aFolderName, aSession);
      if (!lFolder.AllowDeleteThis(aSession))
        throw new FtpException(550, String.Format("Cannot delete folder \"{0}\", permission to delete folder denied.",aFolderName));
      lock(this)
      {
        lFolder.Invalidate();
        SubFolderList.Remove(aFolderName.ToLower());
        throw new FtpException(String.Format("A file named \"{0}\" does not exists.",aFilename));
      if (!AllowDeleteItems(aSession))
        throw new FtpException(550, String.Format("Cannot delete fike \"{0}\", permission to delete from this folder denied.",aFilename));
      IFtpFile lFile = GetFile(aFilename, aSession);
      if (!lFile.AllowDelete(aSession))
        throw new FtpException(550, String.Format("Cannot delete file \"{0}\", permission to delete file denied.",aFilename));
      lock(this)
      {
        lFile.Invalidate();
        FileList.Remove(aFilename.ToLower());
    #endregion
      {
        if (!AllowRenameItems(aSession))
          throw new FtpException(550, String.Format("Cannot rename folder \"{0}\", permission to rename in this folder denied.",aOldFilename));
      else if (HasFile(aOldFilename))
      {
        if (!AllowRenameItems(aSession))
          throw new FtpException(550, String.Format("Cannot rename file \"{0}\", permission to rename in this folder denied.",aOldFilename));
        IFtpFile lFile = GetFile(aOldFilename, aSession);
        if (!lFile.AllowRename(aSession))
          throw new FtpException(550, String.Format("Cannot rename file \"{0}\", permission to rename file denied.",aOldFilename));
        lock (this)
        {
          lFile.Name = aNewFilename;
        }
      }
      else
      {
        throw new FtpException(String.Format("A file or folder named \"{0}\" does not exists.",aOldFilename));
    
}