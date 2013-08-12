/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.file
{
	/// <summary>A Reference is an object which holds a loaded sprite.</summary>
	/// <remarks>A Reference is an object which holds a loaded sprite.</remarks>
	/// <author>Trixt0r</author>
	public class Reference
	{
		public int folder;

		public int file;

		public string folderName;

		public string fileName;

		public com.brashmonkey.spriter.SpriterRectangle dimensions;

		public float pivotX;

		public float pivotY;

		public Reference(int folder, int file, string folderName, string fileName)
		{
			this.folder = folder;
			this.file = file;
			this.folderName = folderName;
			this.fileName = fileName;
		}

		public Reference(int folder, int file) : this(folder, file, null, null)
		{
		}

		public virtual int getFolder()
		{
			return folder;
		}

		public virtual int getFile()
		{
			return file;
		}

		public override int GetHashCode()
		{
			return (folder + "," + file).GetHashCode();
		}

		public override bool Equals(object @ref)
		{
			if (!(@ref is com.brashmonkey.spriter.file.Reference))
			{
				return false;
			}
			//return ((Reference)ref).file == this.file && ((Reference)ref).folder == this.folder;
			return ((com.brashmonkey.spriter.file.Reference)@ref).GetHashCode() == this.GetHashCode
				();
		}
	}
}
