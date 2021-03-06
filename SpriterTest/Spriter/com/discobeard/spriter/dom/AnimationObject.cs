/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */



namespace com.discobeard.spriter.dom
{
	/// <summary><p>Java class for AnimationObject complex type.</summary>
	/// <remarks>
	/// <p>Java class for AnimationObject complex type.
	/// <p>The following schema fragment specifies the expected content contained within this class.
	/// <pre>
	/// &lt;complexType name="AnimationObject"&gt;
	/// &lt;complexContent&gt;
	/// &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
	/// &lt;attribute name="folder" type="{http://www.w3.org/2001/XMLSchema}int" /&gt;
	/// &lt;attribute name="file" type="{http://www.w3.org/2001/XMLSchema}int" /&gt;
	/// &lt;attribute name="x" type="{http://www.w3.org/2001/XMLSchema}decimal" default="0" /&gt;
	/// &lt;attribute name="y" type="{http://www.w3.org/2001/XMLSchema}decimal" default="0" /&gt;
	/// &lt;attribute name="pivot_x" type="{http://www.w3.org/2001/XMLSchema}decimal" default="0" /&gt;
	/// &lt;attribute name="pivot_y" type="{http://www.w3.org/2001/XMLSchema}decimal" default="1" /&gt;
	/// &lt;attribute name="scale_x" type="{http://www.w3.org/2001/XMLSchema}decimal" default="1" /&gt;
	/// &lt;attribute name="scale_y" type="{http://www.w3.org/2001/XMLSchema}decimal" default="1" /&gt;
	/// &lt;attribute name="angle" type="{http://www.w3.org/2001/XMLSchema}decimal" default="0" /&gt;
	/// &lt;attribute name="a" type="{http://www.w3.org/2001/XMLSchema}decimal" default="1" /&gt;
	/// &lt;attribute name="z_index" type="{http://www.w3.org/2001/XMLSchema}int" default="0" /&gt;
	/// &lt;/restriction&gt;
	/// &lt;/complexContent&gt;
	/// &lt;/complexType&gt;
	/// </pre>
	/// </remarks>
	public class AnimationObject
	{
		protected internal int folder;

		protected internal int file;

		protected internal float x;

		protected internal float y;

		protected internal float pivotX = 0f;

		protected internal float pivotY = 1f;

		protected internal float scaleX = 1f;

		protected internal float scaleY = 1f;

		protected internal float angle;

		protected internal float a = 1f;

		protected internal int zIndex;

		//
		// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, vhudson-jaxb-ri-2.1-2 
		// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
		// Any modifications to this file will be lost upon recompilation of the source schema. 
		// Generated on: 2013.01.18 at 06:33:53 PM MEZ 
		//
		/// <summary>Gets the value of the folder property.</summary>
		/// <remarks>Gets the value of the folder property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="int"></see>
		/// </returns>
		public virtual int getFolder()
		{
			return folder;
		}

		/// <summary>Sets the value of the folder property.</summary>
		/// <remarks>Sets the value of the folder property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="int"></see>
		/// </param>
		public virtual void setFolder(int value)
		{
			this.folder = value;
		}

		/// <summary>Gets the value of the file property.</summary>
		/// <remarks>Gets the value of the file property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="int"></see>
		/// </returns>
		public virtual int getFile()
		{
			return file;
		}

		/// <summary>Sets the value of the file property.</summary>
		/// <remarks>Sets the value of the file property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="int"></see>
		/// </param>
		public virtual void setFile(int value)
		{
			this.file = value;
		}

		/// <summary>Gets the value of the x property.</summary>
		/// <remarks>Gets the value of the x property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="int"></see>
		/// </returns>
		public virtual float getX()
		{
			return x;
		}

		/// <summary>Sets the value of the x property.</summary>
		/// <remarks>Sets the value of the x property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="float"></see>
		/// </param>
		public virtual void setX(float value)
		{
			this.x = value;
		}

		/// <summary>Gets the value of the y property.</summary>
		/// <remarks>Gets the value of the y property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="float"></see>
		/// </returns>
		public virtual float getY()
		{
			return y;
		}

		/// <summary>Sets the value of the y property.</summary>
		/// <remarks>Sets the value of the y property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="float"></see>
		/// </param>
		public virtual void setY(float value)
		{
			this.y = value;
		}

		/// <summary>Gets the value of the pivotX property.</summary>
		/// <remarks>Gets the value of the pivotX property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="float"></see>
		/// </returns>
		public virtual float getPivotX()
		{
			return pivotX;
		}

		/// <summary>Sets the value of the pivotX property.</summary>
		/// <remarks>Sets the value of the pivotX property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="float"></see>
		/// </param>
		public virtual void setPivotX(float value)
		{
			this.pivotX = value;
		}

		/// <summary>Gets the value of the pivotY property.</summary>
		/// <remarks>Gets the value of the pivotY property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="float"></see>
		/// </returns>
		public virtual float getPivotY()
		{
			return pivotY;
		}

		/// <summary>Sets the value of the pivotY property.</summary>
		/// <remarks>Sets the value of the pivotY property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="float"></see>
		/// </param>
		public virtual void setPivotY(float value)
		{
			this.pivotY = value;
		}

		/// <summary>Gets the value of the scaleX property.</summary>
		/// <remarks>Gets the value of the scaleX property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="float"></see>
		/// </returns>
		public virtual float getScaleX()
		{
				
            return scaleX;
		}

		/// <summary>Sets the value of the scaleX property.</summary>
		/// <remarks>Sets the value of the scaleX property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="float"></see>
		/// </param>
		public virtual void setScaleX(float value)
		{
			this.scaleX = value;
		}

		/// <summary>Gets the value of the scaleY property.</summary>
		/// <remarks>Gets the value of the scaleY property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="float"></see>
		/// </returns>
		public virtual float getScaleY()
		{
            return scaleY;
		}

		/// <summary>Sets the value of the scaleY property.</summary>
		/// <remarks>Sets the value of the scaleY property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="float"></see>
		/// </param>
		public virtual void setScaleY(float value)
		{
			this.scaleY = value;
		}

		/// <summary>Gets the value of the angle property.</summary>
		/// <remarks>Gets the value of the angle property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="float"></see>
		/// </returns>
		public virtual float getAngle()
		{
			return angle;
		}

		/// <summary>Sets the value of the angle property.</summary>
		/// <remarks>Sets the value of the angle property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="float"></see>
		/// </param>
		public virtual void setAngle(float value)
		{
			this.angle = value;
		}

		/// <summary>Gets the value of the a property.</summary>
		/// <remarks>Gets the value of the a property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="float"></see>
		/// </returns>
		public virtual float getA()
		{
			return a;
		}

		/// <summary>Sets the value of the a property.</summary>
		/// <remarks>Sets the value of the a property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="float"></see>
		/// </param>
		public virtual void setA(float value)
		{
			this.a = value;
		}

		/// <summary>Gets the value of the zIndex property.</summary>
		/// <remarks>Gets the value of the zIndex property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="int"></see>
		/// </returns>
		public virtual int getZIndex()
		{
			return zIndex;
		}

		/// <summary>Sets the value of the zIndex property.</summary>
		/// <remarks>Sets the value of the zIndex property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="int"></see>
		/// </param>
		public virtual void setZIndex(int value)
		{
			this.zIndex = value;
		}
	}
}
