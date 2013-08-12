/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;
using System.Xml;
using System.IO;
using System;
using System.Collections.Generic;

namespace com.brashmonkey.spriter.xml
{
	/// <summary>This class was implemented to give you the chance loading scml files on android with libGDX since JAXB does not run on android devices.
	/// 	</summary>
	/// <remarks>
	/// This class was implemented to give you the chance loading scml files on android with libGDX since JAXB does not run on android devices.
	/// If you are using libGDX, you should use this class to load scml files.
	/// </remarks>
	/// <author>Trixt0r</author>
	public class SCMLReader
	{
		private static com.discobeard.spriter.dom.SpriterData data;

		/// <summary>Reads the whole given scml file.</summary>
		/// <remarks>Reads the whole given scml file.</remarks>
		/// <param name="filename">Path to scml file.</param>
		/// <returns>Spriter data in form of lists.</returns>
		public static com.discobeard.spriter.dom.SpriterData load(string filename)
		{
			try
			{
                FileStream stream = new FileStream(filename, FileMode.Open);
                return load(stream);
			}
			catch (java.io.FileNotFoundException e)
			{
				Sharpen.Runtime.PrintStackTrace(e);
			}
			return null;
		}

        private static com.discobeard.spriter.dom.SpriterData load(FileStream stream)
        {
            XmlReader reader = new XmlReader();
            reader.parse(stream);
            XmlNode root = reader.getNode("spriter_data");
            data = new discobeard.spriter.dom.SpriterData();
            loadFolders(XmlReader.getChildrenByName(root, "folder"));
            loadEntities(XmlReader.getChildrenByName(root, "entity"));
			return data;
		}

		private static void loadFolders(List<XmlNode> folders)
		{
			for (int i = 0; i < folders.Count; i++)
			{
				XmlNode repo = folders[i];
				com.discobeard.spriter.dom.Folder folder = new com.discobeard.spriter.dom.Folder(
					);
				folder.setId(XmlReader.getInt(repo,"id" ));

				folder.setName(XmlReader.getAttribute(repo,"name" ));
				List<XmlNode> files = XmlReader.getChildrenByName(repo,"file");
				for (int j = 0; j < files.Count; j++)
				{
					XmlNode f = files[j];
					com.discobeard.spriter.dom.File file = new com.discobeard.spriter.dom.File();
					file.setId(XmlReader.getInt(f,"id" ));
					file.setName(XmlReader.getAttribute(f,"name" ));
					file.setWidth(XmlReader.getInt(f,"width" ));
					file.setHeight(XmlReader.getInt(f,"height" ));
					try
					{
						file.setPivotX(XmlReader.getFloat(f,"pivot_x" ));
						file.setPivotY(XmlReader.getFloat(f,"pivot_y" ));
					}
					catch (System.Exception)
					{
						file.setPivotX(System.Convert.ToSingle(0));
						file.setPivotY(System.Convert.ToSingle(1));
					}
					folder.getFile().Add(file);
				}
				data.getFolder().Add(folder);
			}
		}

		private static void loadEntities(List<XmlNode> entities)
		{
			for (int i = 0; i < entities.Count; i++)
			{
				XmlNode e = entities[i];
				com.discobeard.spriter.dom.Entity entity = new com.discobeard.spriter.dom.Entity();
				entity.setId(XmlReader.getInt(e,"id" ));
				entity.setName(XmlReader.getAttribute(e,"name" ));
				data.getEntity().Add(entity);
				loadAnimations(XmlReader.getChildrenByName(e,"animation"), entity);
			}
		}

		private static void loadAnimations(List<XmlNode
			> animations, com.discobeard.spriter.dom.Entity entity)
		{
			for (int i = 0; i < animations.Count; i++)
			{
				XmlNode a = animations[i];
				com.discobeard.spriter.dom.Animation animation = new com.discobeard.spriter.dom.Animation
					();
				animation.setId(XmlReader.getInt(a,"id" ));
				animation.setName(XmlReader.getAttribute(a,"name" ));
				animation.setLength(XmlReader.getInt(a,"length" ));
				animation.setLooping(XmlReader.getBool(a,"looping"));
				entity.getAnimation().Add(animation);
				loadMainline(XmlReader.getChildByName(a,"mainline"), animation);
				loadTimelines(XmlReader.getChildrenByName(a,"timeline"), animation);
			}
		}

		private static void loadMainline(XmlNode mainline
			, com.discobeard.spriter.dom.Animation animation)
		{
			com.discobeard.spriter.dom.MainLine main = new com.discobeard.spriter.dom.MainLine
				();
			animation.setMainline(main);
            loadMainlineKeys(XmlReader.getChildrenByName(mainline, "key"), main);
		}

		private static void loadMainlineKeys(List<XmlNode
			> keys, com.discobeard.spriter.dom.MainLine main)
		{
			for (int i = 0; i < keys.Count; i++)
			{
				XmlNode k = keys[i];
				com.discobeard.spriter.dom.Key key = new com.discobeard.spriter.dom.Key();
				key.setId(XmlReader.getInt(k,"id" ));
                int time = XmlReader.getInt(k, "time", -1);
                if (time == -1) key.setTime(0);
                else key.setTime(System.Convert.ToInt64(time));
				main.getKey().Add(key);
                loadRefs(XmlReader.getChildrenByName(k, "object_ref"), XmlReader.getChildrenByName(k, "bone_ref"), key);
			}
		}

		private static void loadRefs(List<XmlNode
			> objectRefs, List<XmlNode
			> boneRefs, com.discobeard.spriter.dom.Key key)
		{
			for (int i = 0; i < boneRefs.Count; i++)
			{
				XmlNode o = boneRefs[i];
				com.discobeard.spriter.dom.BoneRef bone = new com.discobeard.spriter.dom.BoneRef(
					);
				bone.setId(XmlReader.getInt(o,"id" ));
				bone.setKey(XmlReader.getInt(o,"key" ));
                int par = XmlReader.getInt(o, "parent", -1);
                bone.setParent(par);
				bone.setTimeline(XmlReader.getInt(o,"timeline" ));
				key.getBoneRef().Add(bone);
			}
			for (int i_1 = 0; i_1 < objectRefs.Count; i_1++)
			{
				XmlNode o = objectRefs[i_1];
				com.discobeard.spriter.dom.AnimationObjectRef @object = new com.discobeard.spriter.dom.AnimationObjectRef
					();
				@object.setId(XmlReader.getInt(o,"id" ));
				@object.setKey(XmlReader.getInt(o,"key" ));
                int par = XmlReader.getInt(o, "parent", -1);
				@object.setParent(par);
				@object.setTimeline(XmlReader.getInt(o,"timeline" ));
				@object.setZIndex(XmlReader.getInt(o,"z_index" ));
				key.getObjectRef().Add(@object);
			}
		}

		private static void loadTimelines(List<XmlNode
			> timelines, com.discobeard.spriter.dom.Animation animation)
		{
			for (int i = 0; i < timelines.Count; i++)
			{
				com.discobeard.spriter.dom.TimeLine timeline = new com.discobeard.spriter.dom.TimeLine
					();
				timeline.setId(XmlReader.getInt(timelines[i],"id" ));
				animation.getTimeline().Add(timeline);
				loadTimelineKeys(XmlReader.getChildrenByName(timelines[i],"key"), timeline);
			}
		}

		private static void loadTimelineKeys(List<XmlNode> keys, 
            com.discobeard.spriter.dom.TimeLine timeline)
		{
			for (int i = 0; i < keys.Count; i++)
			{
				XmlNode k = keys[i];
                XmlNode obj = XmlReader.getChildByName(k, "bone");
				com.discobeard.spriter.dom.Key key = new com.discobeard.spriter.dom.Key();
				key.setId(XmlReader.getInt(k,"id" ));
				key.setSpin(XmlReader.getInt(k,"spin", 1));
				key.setTime(System.Convert.ToInt64(XmlReader.getInt(k,"time", 0 )));
                string name = XmlReader.getAttribute(k.ParentNode, "name");
				timeline.setName(name);
				if (obj != null)
				{
					com.discobeard.spriter.dom.Bone bone = new com.discobeard.spriter.dom.Bone();
					bone.setAngle(new java.math.BigDecimal(XmlReader.getFloat(obj,"angle", 0f )));
					bone.setX(new java.math.BigDecimal(XmlReader.getFloat(obj,"x", 0f )));
					bone.setY(new java.math.BigDecimal(XmlReader.getFloat(obj,"y", 0f )));
					bone.setScaleX(new java.math.BigDecimal(XmlReader.getFloat(obj,"scale_x", 1f )));
					bone.setScaleY(new java.math.BigDecimal(XmlReader.getFloat(obj,"scale_y", 1f )));
					key.setBone(bone);
				}
				else
				{
					com.discobeard.spriter.dom.AnimationObject @object = new com.discobeard.spriter.dom.AnimationObject
						();
                    obj = XmlReader.getChildByName(k, "object");
					@object.setAngle(new java.math.BigDecimal(XmlReader.getFloat(obj,"angle", 0f )));
					@object.setX(new java.math.BigDecimal(XmlReader.getFloat(obj,"x", 0f )));
					@object.setY(new java.math.BigDecimal(XmlReader.getFloat(obj,"y", 0f )));
					@object.setScaleX(new java.math.BigDecimal(XmlReader.getFloat(obj,"scale_x", 1f )));
					@object.setScaleY(new java.math.BigDecimal(XmlReader.getFloat(obj,"scale_y", 1f )));
					@object.setFolder(XmlReader.getInt(obj,"folder" ));
					@object.setFile(XmlReader.getInt(obj,"file" ));
					com.discobeard.spriter.dom.File f = data.getFolder()[@object.getFolder()].getFile
						()[@object.getFile()];
					@object.setPivotX(new java.math.BigDecimal(XmlReader.getFloat(obj,"pivot_x", f.getPivotX( ))
						));
					@object.setPivotY(new java.math.BigDecimal(XmlReader.getFloat(obj,"pivot_y", f.getPivotY( ))
						));
					key.getObject().Add(@object);
				}
				timeline.getKey().Add(key);
			}
		}

		public virtual com.discobeard.spriter.dom.SpriterData getCurrentSpriterData()
		{
			return data;
		}
	}
}
