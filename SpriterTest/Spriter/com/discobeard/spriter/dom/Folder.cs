/*
 * This code is derived from MyJavaLibrary (http://somelinktomycoollibrary)
 * 
 * If this is an open source Java library, include the proper license and copyright attributions here!
 */


using System.Collections.Generic;

namespace com.discobeard.spriter.dom
{
	/// <summary><p>Java class for Folder complex type.</summary>
	/// <remarks>
	/// <p>Java class for Folder complex type.
	/// <p>The following schema fragment specifies the expected content contained within this class.
	/// <pre>
	/// &lt;complexType name="Folder"&gt;
	/// &lt;complexContent&gt;
	/// &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
	/// &lt;sequence&gt;
	/// &lt;element name="file" type="{}File" maxOccurs="unbounded" minOccurs="0"/&gt;
	/// &lt;/sequence&gt;
	/// &lt;attribute name="id" type="{http://www.w3.org/2001/XMLSchema}int" /&gt;
	/// &lt;attribute name="name" type="{http://www.w3.org/2001/XMLSchema}string" /&gt;
	/// &lt;/restriction&gt;
	/// &lt;/complexContent&gt;
	/// &lt;/complexType&gt;
	/// </pre>
	/// </remarks>
	public class Folder
	{
		protected internal IList<File> file;

		protected internal int id;

		protected internal string name;

		//
		// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, vhudson-jaxb-ri-2.1-2 
		// See <a href="http://java.sun.com/xml/jaxb">http://java.sun.com/xml/jaxb</a> 
		// Any modifications to this file will be lost upon recompilation of the source schema. 
		// Generated on: 2013.01.18 at 06:33:53 PM MEZ 
		//
		/// <summary>Gets the value of the file property.</summary>
		/// <remarks>
		/// Gets the value of the file property.
		/// <p>
		/// This accessor method returns a reference to the live list,
		/// not a snapshot. Therefore any modification you make to the
		/// returned list will be present inside the JAXB object.
		/// This is why there is not a <CODE>set</CODE> method for the file property.
		/// <p>
		/// For example, to add a new item, do as follows:
		/// <pre>
		/// getFile().add(newItem);
		/// </pre>
		/// <p>
		/// Objects of the following type(s) are allowed in the list
		/// <see cref="File"></see>
		/// </remarks>
		public virtual IList<File> 
			getFile()
		{
			if (file == null)
			{
				file = new List<File>();
			}
			return this.file;
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
	}
}
