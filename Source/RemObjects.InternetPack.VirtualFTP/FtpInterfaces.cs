using System;
using System.Collections;
using System.IO;
using System.Net;
using RemObjects.InternetPack;

namespace RemObjects.InternetPack.Ftp.VirtualFtp
{

  public interface IFtpItem
  {
    IFtpFolder Parent { get; set; }

  public interface IFtpFolder: IFtpItem
  {
    IFtpFolder Root { get ; }

  public interface IFtpFile: IFtpItem
  {
    int Size { get ; }
    bool AllowGet(VirtualFtpSession aSession);

  public interface IFtpUserManager
  {
    bool CheckIP(EndPoint aRemote, EndPoint aLocal);
    bool CheckLogin(string aUsername, string aPassword, VirtualFtpSession aSession);


}