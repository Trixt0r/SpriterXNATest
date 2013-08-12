/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.brashmonkey.spriter.objects
{
	/// <summary>A SpriterModObject is an object which is able to manipulate animated bones and objects at runtime.
	/// 	</summary>
	/// <remarks>A SpriterModObject is an object which is able to manipulate animated bones and objects at runtime.
	/// 	</remarks>
	/// <author>Trixt0r</author>
	public class SpriterModObject : com.brashmonkey.spriter.objects.SpriterAbstractObject
	{
		private float alpha;

		private com.brashmonkey.spriter.file.Reference @ref;

		private com.brashmonkey.spriter.file.FileLoader loader;

		private bool active;

		public SpriterModObject() : base()
		{
			this.alpha = 1f;
			this.@ref = null;
			//this.loader = null;
			this.active = true;
		}

		public virtual float getAlpha()
		{
			return alpha;
		}

		public virtual void setAlpha(float alpha)
		{
			this.alpha = alpha;
		}

		public virtual com.brashmonkey.spriter.file.Reference getRef()
		{
			return @ref;
		}

		public virtual void setRef(com.brashmonkey.spriter.file.Reference @ref)
		{
			this.@ref = @ref;
		}

		public virtual com.brashmonkey.spriter.file.FileLoader getLoader()
		{
			return loader;
		}

		public virtual void setLoader(com.brashmonkey.spriter.file.FileLoader loader)
		{
			this.loader = loader;
		}

		public virtual bool isActive()
		{
			return active;
		}

		public virtual void setActive(bool active)
		{
			this.active = active;
		}

		private void modObject(com.brashmonkey.spriter.objects.SpriterAbstractObject @object
			)
		{
			@object.setAngle(@object.getAngle() + this.angle);
			@object.setScaleX(@object.getScaleX() * this.scaleX);
			@object.setScaleY(@object.getScaleY() * this.scaleY);
			@object.setX(@object.getX() + this.x);
			@object.setY(@object.getY() + this.y);
		}

		/// <summary>Manipulates the given object.</summary>
		/// <remarks>Manipulates the given object.</remarks>
		/// <param name="object"></param>
		public virtual void modSpriterObject(com.brashmonkey.spriter.objects.SpriterObject
			 @object)
		{
			this.modObject(@object);
			@object.setAlpha(@object.getAlpha() * this.alpha);
		}

		/// <summary>Manipulates the given bone.</summary>
		/// <remarks>Manipulates the given bone.</remarks>
		/// <param name="bone"></param>
		public virtual void modSpriterBone(com.brashmonkey.spriter.objects.SpriterBone bone
			)
		{
			this.modObject(bone);
		}
	}
}
