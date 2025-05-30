namespace Packt.Shared;

public static class PathExtensions
{
  extension(Path)
  {
    public static bool? IsFile(string path)
    {
      var isDir = IsDirectory(path);
      return isDir == null ? null : !isDir;
    }

    public static bool? IsDirectory(string path)
    {
      if (Directory.Exists(path))
        return true;

      if (File.Exists(path))
        return false;

      return null;
    }
  }
}
