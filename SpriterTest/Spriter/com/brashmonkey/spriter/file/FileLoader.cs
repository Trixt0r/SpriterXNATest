/**************************************************************************
 * Copyright 2013 by Trixt0r
 * (https://github.com/Trixt0r, Heinrich Reich, e-mail: trixter16@web.de)
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LobjectCENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS objectS" BASobjectS,
 * WobjectTHOUT WARRANTobjectES OR CONDobjectTobjectONS OF ANY KobjectND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
***************************************************************************/using Sharpen;

namespace com.brashmonkey.spriter.file
{
	/// <summary>A FileLoader is an object which takes the task to load the resources a Spriter entity needs.
	/// 	</summary>
	/// <remarks>
	/// A FileLoader is an object which takes the task to load the resources a Spriter entity needs.
	/// This is an abstract implementation and you need to extend this class and specify the logic of
	/// <see cref="FileLoader{object}.load(Reference, string)">FileLoader&lt;object&gt;.load(Reference, string)
	/// 	</see>
	/// .
	/// </remarks>
	/// <author>Trixt0r</author>
	/// <?></?>
	public abstract class FileLoader
	{
		public System.Collections.Generic.Dictionary<com.brashmonkey.spriter.file.Reference
			, object> files = new System.Collections.Generic.Dictionary<com.brashmonkey.spriter.file.Reference
			, object>();

		public abstract void load(com.brashmonkey.spriter.file.Reference @ref, string path
			);

		/// <summary>objects called if all resources have been passed to this loader.</summary>
		/// <remarks>objects called if all resources have been passed to this loader.</remarks>
		public virtual void finishLoading()
		{
		}

		//To be implemented by your specific backend loader.
		public virtual object get(com.brashmonkey.spriter.file.Reference @ref)
		{
			return files.Get(@ref);
		}

		/// <returns>Array of all loaded references by this loader.</returns>
		public virtual com.brashmonkey.spriter.file.Reference[] getRefs()
		{
			com.brashmonkey.spriter.file.Reference[] refs = new com.brashmonkey.spriter.file.Reference
				[Sharpen.Collections.ToArray(this.files.Keys).Length];
			Sharpen.Collections.ToArray(this.files.Keys, refs);
			return refs;
		}

		/// <summary>Searches for a reference which is equal to the given one.</summary>
		/// <remarks>
		/// Searches for a reference which is equal to the given one.
		/// Equal means: the folder and file of two references are the same.
		/// </remarks>
		/// <param name="ref">Reference to search after.</param>
		/// <returns>Corresponding reference or null if not found.</returns>
		public virtual com.brashmonkey.spriter.file.Reference findReference(com.brashmonkey.spriter.file.Reference
			 @ref)
		{
			com.brashmonkey.spriter.file.Reference[] refs = this.getRefs();
			foreach (com.brashmonkey.spriter.file.Reference r in refs)
			{
				if (r.Equals(@ref))
				{
					return r;
				}
			}
			return null;
		}

		/// <summary>Searches for all files in the given folder name.</summary>
		/// <remarks>Searches for all files in the given folder name.</remarks>
		/// <param name="folderName">folder to search in</param>
		/// <returns>array of all references which the given folder contains.</returns>
		public virtual com.brashmonkey.spriter.file.Reference[] findReferencesByFolderName
			(string folderName)
		{
			com.brashmonkey.spriter.file.Reference[] refs = this.getRefs();
			System.Collections.Generic.List<com.brashmonkey.spriter.file.Reference> files = new 
				System.Collections.Generic.List<com.brashmonkey.spriter.file.Reference>();
			foreach (com.brashmonkey.spriter.file.Reference @ref in refs)
			{
				if (@ref.folderName.Equals(folderName))
				{
					files.Add(@ref);
				}
			}
			return Sharpen.Collections.ToArray(files, refs);
		}

		/// <summary>Searches for a reference with the given filename and returns it, if it exists.
		/// 	</summary>
		/// <remarks>Searches for a reference with the given filename and returns it, if it exists.
		/// 	</remarks>
		/// <param name="fileName">name of the file (complete name with folder name and extension)
		/// 	</param>
		/// <returns>reference with given filename or null if not found</returns>
		public virtual com.brashmonkey.spriter.file.Reference findReferenceByFileName(string
			 fileName)
		{
			com.brashmonkey.spriter.file.Reference[] refs = this.getRefs();
			foreach (com.brashmonkey.spriter.file.Reference @ref in refs)
			{
				if (@ref.fileName.Equals(fileName))
				{
					return @ref;
				}
			}
			return null;
		}

		/// <summary>Searches for a reference with the given filename and folder id and returns it, if it exists.
		/// 	</summary>
		/// <remarks>Searches for a reference with the given filename and folder id and returns it, if it exists.
		/// 	</remarks>
		/// <param name="fileName">name of the file (relative name to the given folder)</param>
		/// <param name="folderName">name of the folder in which the file is.</param>
		/// <param name="withoutExtension">indicates whether to compare with the file extension or not. false means, the extension will be compared, too.
		/// 	</param>
		/// <returns>the right reference to the file or null if not found</returns>
		public virtual com.brashmonkey.spriter.file.Reference findReferenceByFileNameAndFolder
			(string fileName, string folderName, bool withoutExtension)
		{
			com.brashmonkey.spriter.file.Reference[] refs = this.findReferencesByFolderName(folderName
				);
			foreach (com.brashmonkey.spriter.file.Reference @ref in refs)
			{
				string file = @ref.fileName.ReplaceAll(folderName + "/", string.Empty);
				if (withoutExtension)
				{
					file = file.ReplaceAll(".png", string.Empty);
				}
				if (file.Equals(fileName))
				{
					return @ref;
				}
			}
			return null;
		}
	}
}
