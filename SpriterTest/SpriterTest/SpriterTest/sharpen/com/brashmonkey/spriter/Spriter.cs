/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter
{
	/// <summary>This class reads an scml file and loads all necessary resources.</summary>
	/// <remarks>This class reads an scml file and loads all necessary resources.</remarks>
	/// <author>Discobeard.com, Trixt0r</author>
    public class Spriter
	{
		/// <summary>Creates a spriter object.</summary>
		/// <remarks>Creates a spriter object.</remarks>
		/// <param name="path">Path to the scml file</param>
		/// <param name="drawer">a drawer extended from the AbstractDrawer</param>
		/// <param name="loader">a loader extended from the AbstractLoader</param>
		/// <returns>a Spriter Object</returns>
        /* public static com.brashmonkey.spriter.Spriter getSpriter<object>(string path, com.brashmonkey.spriter.file.FileLoader<_T0> loader)
		{
			return new com.brashmonkey.spriter.Spriter(path, loader);
		}*/

		public readonly com.brashmonkey.spriter.file.FileLoader loader;

		public readonly java.io.File scmlFile;

		public readonly com.discobeard.spriter.dom.SpriterData spriterData;

        public Spriter(string scmlPath, com.brashmonkey.spriter.file.FileLoader loader
			)
		{
			this.scmlFile = new java.io.File(scmlPath);
			this.spriterData = com.brashmonkey.spriter.xml.SCMLReader.load(scmlPath);
			this.loader = loader;
			loadResources();
		}

		public Spriter(com.discobeard.spriter.dom.SpriterData spriterData, com.brashmonkey.spriter.file.FileLoader loader, java.io.File scmlFile)
		{
			this.scmlFile = scmlFile;
			this.spriterData = spriterData;
			this.loader = loader;
			this.loadResources();
		}

		private void loadResources()
		{
			for (int folder = 0; folder < spriterData.getFolder().Count; folder++)
			{
				for (int file = 0; file < spriterData.getFolder()[folder].getFile().Count; file++)
				{
					string folderName = spriterData.getFolder()[folder].getName();
					string fileName = spriterData.getFolder()[folder].getFile()[file].getName();
					com.brashmonkey.spriter.file.Reference @ref = new com.brashmonkey.spriter.file.Reference
						(folder, file, folderName, fileName);
					@ref.dimensions = new com.brashmonkey.spriter.SpriterRectangle(0, spriterData.getFolder
						()[folder].getFile()[file].getHeight(), spriterData.getFolder()[folder].getFile(
						)[file].getWidth(), 0);
					@ref.pivotX = spriterData.getFolder()[folder].getFile()[file].getPivotX();
					@ref.pivotY = spriterData.getFolder()[folder].getFile()[file].getPivotY();
					loader.load(@ref, scmlFile.getParent() + "/" + fileName);
				}
			}
			this.loader.finishLoading();
		}

		/// <returns>Spriter data which has been read from the scml file before.</returns>
		public virtual com.discobeard.spriter.dom.SpriterData getSpriterData()
		{
			return this.spriterData;
		}
    }
}
