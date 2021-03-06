/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */

using Sharpen;

namespace com.discobeard.spriter.dom
{
	/// <summary><p>Java class for Key complex type.</summary>
	/// <remarks>
	/// <p>Java class for Key complex type.
	/// <p>The following schema fragment specifies the expected content contained within this class.
	/// <pre>
	/// &lt;complexType name="Key"&gt;
	/// &lt;complexContent&gt;
	/// &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
	/// &lt;sequence&gt;
	/// &lt;element name="object" type="{}AnimationObject" maxOccurs="unbounded" minOccurs="0"/&gt;
	/// &lt;element name="object_ref" type="{}AnimationObjectRef" maxOccurs="unbounded" minOccurs="0"/&gt;
	/// &lt;element name="bone_ref" type="{}BoneRef" maxOccurs="unbounded" minOccurs="0"/&gt;
	/// &lt;element name="bone" type="{}Bone" minOccurs="0"/&gt;
	/// &lt;/sequence&gt;
	/// &lt;attribute name="id" type="{http://www.w3.org/2001/XMLSchema}int" /&gt;
	/// &lt;attribute name="time" type="{http://www.w3.org/2001/XMLSchema}long" default="0" /&gt;
	/// &lt;attribute name="spin" type="{http://www.w3.org/2001/XMLSchema}int" default="1" /&gt;
	/// &lt;/restriction&gt;
	/// &lt;/complexContent&gt;
	/// &lt;/complexType&gt;
	/// </pre>
	/// </remarks>
	public class Key
	{
		protected internal System.Collections.Generic.IList<com.discobeard.spriter.dom.AnimationObject
			> @object;

		protected internal System.Collections.Generic.IList<com.discobeard.spriter.dom.AnimationObjectRef
			> objectRef;

		protected internal System.Collections.Generic.IList<com.discobeard.spriter.dom.BoneRef
			> boneRef;

		protected internal com.discobeard.spriter.dom.Bone bone;

		protected internal int id;

		protected internal long time;

		protected internal int spin;

		//
		// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, vhudson-jaxb-ri-2.1-2 
		// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
		// Any modifications to this file will be lost upon recompilation of the source schema. 
		// Generated on: 2013.01.18 at 06:33:53 PM MEZ 
		//
		/// <summary>Gets the value of the object property.</summary>
		/// <remarks>
		/// Gets the value of the object property.
		/// <p>
		/// This accessor method returns a reference to the live list,
		/// not a snapshot. Therefore any modification you make to the
		/// returned list will be present inside the JAXB object.
		/// This is why there is not a <CODE>set</CODE> method for the object property.
		/// <p>
		/// For example, to add a new item, do as follows:
		/// <pre>
		/// getObject().add(newItem);
		/// </pre>
		/// <p>
		/// Objects of the following type(s) are allowed in the list
		/// <see cref="AnimationObject"></see>
		/// </remarks>
		public virtual System.Collections.Generic.IList<com.discobeard.spriter.dom.AnimationObject
			> getObject()
		{
			if (@object == null)
			{
				@object = new System.Collections.Generic.List<com.discobeard.spriter.dom.AnimationObject
					>();
			}
			return this.@object;
		}

		/// <summary>Gets the value of the objectRef property.</summary>
		/// <remarks>
		/// Gets the value of the objectRef property.
		/// <p>
		/// This accessor method returns a reference to the live list,
		/// not a snapshot. Therefore any modification you make to the
		/// returned list will be present inside the JAXB object.
		/// This is why there is not a <CODE>set</CODE> method for the objectRef property.
		/// <p>
		/// For example, to add a new item, do as follows:
		/// <pre>
		/// getObjectRef().add(newItem);
		/// </pre>
		/// <p>
		/// Objects of the following type(s) are allowed in the list
		/// <see cref="AnimationObjectRef"></see>
		/// </remarks>
		public virtual System.Collections.Generic.IList<com.discobeard.spriter.dom.AnimationObjectRef
			> getObjectRef()
		{
			if (objectRef == null)
			{
				objectRef = new System.Collections.Generic.List<com.discobeard.spriter.dom.AnimationObjectRef
					>();
			}
			return this.objectRef;
		}

		/// <summary>Gets the value of the boneRef property.</summary>
		/// <remarks>
		/// Gets the value of the boneRef property.
		/// <p>
		/// This accessor method returns a reference to the live list,
		/// not a snapshot. Therefore any modification you make to the
		/// returned list will be present inside the JAXB object.
		/// This is why there is not a <CODE>set</CODE> method for the boneRef property.
		/// <p>
		/// For example, to add a new item, do as follows:
		/// <pre>
		/// getBoneRef().add(newItem);
		/// </pre>
		/// <p>
		/// Objects of the following type(s) are allowed in the list
		/// <see cref="BoneRef"></see>
		/// </remarks>
		public virtual System.Collections.Generic.IList<com.discobeard.spriter.dom.BoneRef
			> getBoneRef()
		{
			if (boneRef == null)
			{
				boneRef = new System.Collections.Generic.List<com.discobeard.spriter.dom.BoneRef>
					();
			}
			return this.boneRef;
		}

		/// <summary>Gets the value of the bone property.</summary>
		/// <remarks>Gets the value of the bone property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="Bone"></see>
		/// </returns>
		public virtual com.discobeard.spriter.dom.Bone getBone()
		{
			return bone;
		}

		/// <summary>Sets the value of the bone property.</summary>
		/// <remarks>Sets the value of the bone property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="Bone"></see>
		/// </param>
		public virtual void setBone(com.discobeard.spriter.dom.Bone value)
		{
			this.bone = value;
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

		/// <summary>Gets the value of the time property.</summary>
		/// <remarks>Gets the value of the time property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="long"></see>
		/// </returns>
		public virtual long getTime()
		{
			return time;
		}

		/// <summary>Sets the value of the time property.</summary>
		/// <remarks>Sets the value of the time property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="long"></see>
		/// </param>
		public virtual void setTime(long value)
		{
			this.time = value;
		}

		/// <summary>Gets the value of the spin property.</summary>
		/// <remarks>Gets the value of the spin property.</remarks>
		/// <returns>
		/// possible object is
		/// <see cref="int"></see>
		/// </returns>
		public virtual int getSpin()
		{
			return spin;
		}

		/// <summary>Sets the value of the spin property.</summary>
		/// <remarks>Sets the value of the spin property.</remarks>
		/// <param name="value">
		/// allowed object is
		/// <see cref="int"></see>
		/// </param>
		public virtual void setSpin(int value)
		{
			this.spin = value;
		}
	}
}
