﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DisplayQueryResult
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Books")]
	public partial class BooksDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertAuthorISBN(AuthorISBN instance);
    partial void UpdateAuthorISBN(AuthorISBN instance);
    partial void DeleteAuthorISBN(AuthorISBN instance);
    partial void InsertTitle(Title instance);
    partial void UpdateTitle(Title instance);
    partial void DeleteTitle(Title instance);
    partial void InsertAuthor(Author instance);
    partial void UpdateAuthor(Author instance);
    partial void DeleteAuthor(Author instance);
    #endregion
		
		public BooksDataContext() : 
				base(global::DisplayQueryResult.Properties.Settings.Default.BooksConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public BooksDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BooksDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BooksDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public BooksDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<AuthorISBN> AuthorISBNs
		{
			get
			{
				return this.GetTable<AuthorISBN>();
			}
		}
		
		public System.Data.Linq.Table<Title> Titles
		{
			get
			{
				return this.GetTable<Title>();
			}
		}
		
		public System.Data.Linq.Table<Author> Authors
		{
			get
			{
				return this.GetTable<Author>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.AuthorISBN")]
	public partial class AuthorISBN : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _AuthorID;
		
		private string _ISBN;
		
		private EntityRef<Title> _Title;
		
		private EntityRef<Author> _Author;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAuthorIDChanging(int value);
    partial void OnAuthorIDChanged();
    partial void OnISBNChanging(string value);
    partial void OnISBNChanged();
    #endregion
		
		public AuthorISBN()
		{
			this._Title = default(EntityRef<Title>);
			this._Author = default(EntityRef<Author>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuthorID", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int AuthorID
		{
			get
			{
				return this._AuthorID;
			}
			set
			{
				if ((this._AuthorID != value))
				{
					if (this._Author.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnAuthorIDChanging(value);
					this.SendPropertyChanging();
					this._AuthorID = value;
					this.SendPropertyChanged("AuthorID");
					this.OnAuthorIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ISBN", DbType="VarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string ISBN
		{
			get
			{
				return this._ISBN;
			}
			set
			{
				if ((this._ISBN != value))
				{
					if (this._Title.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnISBNChanging(value);
					this.SendPropertyChanging();
					this._ISBN = value;
					this.SendPropertyChanged("ISBN");
					this.OnISBNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Title_AuthorISBN", Storage="_Title", ThisKey="ISBN", OtherKey="ISBN", IsForeignKey=true)]
		public Title Title
		{
			get
			{
				return this._Title.Entity;
			}
			set
			{
				Title previousValue = this._Title.Entity;
				if (((previousValue != value) 
							|| (this._Title.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Title.Entity = null;
						previousValue.AuthorISBNs.Remove(this);
					}
					this._Title.Entity = value;
					if ((value != null))
					{
						value.AuthorISBNs.Add(this);
						this._ISBN = value.ISBN;
					}
					else
					{
						this._ISBN = default(string);
					}
					this.SendPropertyChanged("Title");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Author_AuthorISBN", Storage="_Author", ThisKey="AuthorID", OtherKey="AuthorID", IsForeignKey=true)]
		public Author Author
		{
			get
			{
				return this._Author.Entity;
			}
			set
			{
				Author previousValue = this._Author.Entity;
				if (((previousValue != value) 
							|| (this._Author.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Author.Entity = null;
						previousValue.AuthorISBNs.Remove(this);
					}
					this._Author.Entity = value;
					if ((value != null))
					{
						value.AuthorISBNs.Add(this);
						this._AuthorID = value.AuthorID;
					}
					else
					{
						this._AuthorID = default(int);
					}
					this.SendPropertyChanged("Author");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Titles")]
	public partial class Title : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _ISBN;
		
		private string _Title1;
		
		private int _EditionNumber;
		
		private string _Copyright;
		
		private EntitySet<AuthorISBN> _AuthorISBNs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnISBNChanging(string value);
    partial void OnISBNChanged();
    partial void OnTitle1Changing(string value);
    partial void OnTitle1Changed();
    partial void OnEditionNumberChanging(int value);
    partial void OnEditionNumberChanged();
    partial void OnCopyrightChanging(string value);
    partial void OnCopyrightChanged();
    #endregion
		
		public Title()
		{
			this._AuthorISBNs = new EntitySet<AuthorISBN>(new Action<AuthorISBN>(this.attach_AuthorISBNs), new Action<AuthorISBN>(this.detach_AuthorISBNs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ISBN", DbType="VarChar(20) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string ISBN
		{
			get
			{
				return this._ISBN;
			}
			set
			{
				if ((this._ISBN != value))
				{
					this.OnISBNChanging(value);
					this.SendPropertyChanging();
					this._ISBN = value;
					this.SendPropertyChanged("ISBN");
					this.OnISBNChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Title", Storage="_Title1", DbType="VarChar(100) NOT NULL", CanBeNull=false)]
		public string Title1
		{
			get
			{
				return this._Title1;
			}
			set
			{
				if ((this._Title1 != value))
				{
					this.OnTitle1Changing(value);
					this.SendPropertyChanging();
					this._Title1 = value;
					this.SendPropertyChanged("Title1");
					this.OnTitle1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_EditionNumber", DbType="Int NOT NULL")]
		public int EditionNumber
		{
			get
			{
				return this._EditionNumber;
			}
			set
			{
				if ((this._EditionNumber != value))
				{
					this.OnEditionNumberChanging(value);
					this.SendPropertyChanging();
					this._EditionNumber = value;
					this.SendPropertyChanged("EditionNumber");
					this.OnEditionNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Copyright", DbType="VarChar(4) NOT NULL", CanBeNull=false)]
		public string Copyright
		{
			get
			{
				return this._Copyright;
			}
			set
			{
				if ((this._Copyright != value))
				{
					this.OnCopyrightChanging(value);
					this.SendPropertyChanging();
					this._Copyright = value;
					this.SendPropertyChanged("Copyright");
					this.OnCopyrightChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Title_AuthorISBN", Storage="_AuthorISBNs", ThisKey="ISBN", OtherKey="ISBN")]
		public EntitySet<AuthorISBN> AuthorISBNs
		{
			get
			{
				return this._AuthorISBNs;
			}
			set
			{
				this._AuthorISBNs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_AuthorISBNs(AuthorISBN entity)
		{
			this.SendPropertyChanging();
			entity.Title = this;
		}
		
		private void detach_AuthorISBNs(AuthorISBN entity)
		{
			this.SendPropertyChanging();
			entity.Title = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Authors")]
	public partial class Author : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _AuthorID;
		
		private string _FirstName;
		
		private string _LastName;
		
		private EntitySet<AuthorISBN> _AuthorISBNs;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnAuthorIDChanging(int value);
    partial void OnAuthorIDChanged();
    partial void OnFirstNameChanging(string value);
    partial void OnFirstNameChanged();
    partial void OnLastNameChanging(string value);
    partial void OnLastNameChanged();
    #endregion
		
		public Author()
		{
			this._AuthorISBNs = new EntitySet<AuthorISBN>(new Action<AuthorISBN>(this.attach_AuthorISBNs), new Action<AuthorISBN>(this.detach_AuthorISBNs));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_AuthorID", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int AuthorID
		{
			get
			{
				return this._AuthorID;
			}
			set
			{
				if ((this._AuthorID != value))
				{
					this.OnAuthorIDChanging(value);
					this.SendPropertyChanging();
					this._AuthorID = value;
					this.SendPropertyChanged("AuthorID");
					this.OnAuthorIDChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FirstName", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string FirstName
		{
			get
			{
				return this._FirstName;
			}
			set
			{
				if ((this._FirstName != value))
				{
					this.OnFirstNameChanging(value);
					this.SendPropertyChanging();
					this._FirstName = value;
					this.SendPropertyChanged("FirstName");
					this.OnFirstNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_LastName", DbType="VarChar(30) NOT NULL", CanBeNull=false)]
		public string LastName
		{
			get
			{
				return this._LastName;
			}
			set
			{
				if ((this._LastName != value))
				{
					this.OnLastNameChanging(value);
					this.SendPropertyChanging();
					this._LastName = value;
					this.SendPropertyChanged("LastName");
					this.OnLastNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Author_AuthorISBN", Storage="_AuthorISBNs", ThisKey="AuthorID", OtherKey="AuthorID")]
		public EntitySet<AuthorISBN> AuthorISBNs
		{
			get
			{
				return this._AuthorISBNs;
			}
			set
			{
				this._AuthorISBNs.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_AuthorISBNs(AuthorISBN entity)
		{
			this.SendPropertyChanging();
			entity.Author = this;
		}
		
		private void detach_AuthorISBNs(AuthorISBN entity)
		{
			this.SendPropertyChanging();
			entity.Author = null;
		}
	}
}
#pragma warning restore 1591
