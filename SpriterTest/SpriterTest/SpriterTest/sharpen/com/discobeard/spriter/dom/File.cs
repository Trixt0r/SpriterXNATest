/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.discobeard.spriter.dom
{
	/// <summary><p>Java class for File complex type.</summary>
	/// <remarks>
	/// <p>Java class for File complex type.
	/// <p>The following schema fragment specifies the expected content contained within this class.
	/// <pre>
	/// &lt;complexType name="File"&gt;
	/// &lt;complexContent&gt;
	/// &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
	/// &lt;attribute name="id" type="{http://www.w3.org/2001/XMLSchema}int" /&gt;
	/// &lt;attribute name="name" type="{http://www.w3.org/2001/XMLSchema}string" /&gt;
	/// &lt;attribute name="width" type="{http://www.w3.org/2001/XMLSchema}long" /&gt;
	/// &lt;attribute name="height" type="{http://www.w3.org/2001/XMLSchema}long" /&gt;
	/// &lt;/restriction&gt;
	/// &lt;/complexContent&gt;
	/// &lt;/complexType&gt;
	/// </pre>
	/// </remarks>
	public class File
	{
		protected internal int id;

		protected internal string name;

		protected internal int width;

        protected internal int height;

		protected internal float pivotX;

		protected internal float pivotY;

		//
		// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, vhudson-jaxb-ri-2.1-2 
		// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
		// Any modifications to this file will be lost upon recompilation of the source schema. 
		// Generated on: 2013.01.18 at 06:33:53 PM MEZ 
		//
		/// <returns>the pivotX</returns>
		public virtual float getPivotX()
		{
			return pivotX;
		}

		/// <param name="pivotX">the pivotX to set</param>
		public virtual void setPivotX(float pivotX)
		{
			this.pivotX = pivotX;
		}

		/// <returns>the pivotY</returns>
		public virtual float getPivotY()
		{
			return pivotY;
		}

		/// <param name="pivotY">the pivotY to set</param>
		public virtual void setPivotY(float pivotY)
		{
			this.pivotY = pivotY;
		}

		/// <summary>Gets the value of the id property.</summary>
		/// <remarks>Gets the value of the id property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="int"></see>
		/// </returns>
		public virtual int getId()
		{
			return id;
		}

		/// <summary>Sets the value of the id property.</summary>
		/// <remarks>Sets the value of the id property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="int"></see>
		/// </param>
		public virtual void setId(int value)
		{
			this.id = value;
		}

		/// <summary>Gets the value of the name property.</summary>
		/// <remarks>Gets the value of the name property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="string"></see>
		/// </returns>
		public virtual string getName()
		{
			return name;
		}

		/// <summary>Sets the value of the name property.</summary>
		/// <remarks>Sets the value of the name property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="string"></see>
		/// </param>
		public virtual void setName(string value)
		{
			this.name = value;
		}

		/// <summary>Gets the value of the width property.</summary>
		/// <remarks>Gets the value of the width property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="long"></see>
		/// </returns>
        public virtual int getWidth()
		{
			return width;
		}

		/// <summary>Sets the value of the width property.</summary>
		/// <remarks>Sets the value of the width property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="long"></see>
		/// </param>
        public virtual void setWidth(int value)
		{
			this.width = value;
		}

		/// <summary>Gets the value of the height property.</summary>
		/// <remarks>Gets the value of the height property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="long"></see>
		/// </returns>
        public virtual int getHeight()
		{
			return height;
		}

		/// <summary>Sets the value of the height property.</summary>
		/// <remarks>Sets the value of the height property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="long"></see>
		/// </param>
        public virtual void setHeight(int value)
		{
            this.height = value;
		}
	}
}