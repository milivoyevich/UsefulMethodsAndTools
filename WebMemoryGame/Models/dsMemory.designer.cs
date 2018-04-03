﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebMemoryGame.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="DbMemory")]
	public partial class dsMemoryDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void Insertmem_korisnici(mem_korisnici instance);
    partial void Updatemem_korisnici(mem_korisnici instance);
    partial void Deletemem_korisnici(mem_korisnici instance);
    partial void Insertmem_rezultati(mem_rezultati instance);
    partial void Updatemem_rezultati(mem_rezultati instance);
    partial void Deletemem_rezultati(mem_rezultati instance);
    #endregion
		
		public dsMemoryDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["DbMemoryConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dsMemoryDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dsMemoryDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dsMemoryDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dsMemoryDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<mem_korisnici> mem_korisnicis
		{
			get
			{
				return this.GetTable<mem_korisnici>();
			}
		}
		
		public System.Data.Linq.Table<mem_rezultati> mem_rezultatis
		{
			get
			{
				return this.GetTable<mem_rezultati>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.mem_korisnici")]
	public partial class mem_korisnici : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id;
		
		private string _username;
		
		private string _password;
		
		private string _email;
		
		private string _fullname;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnusernameChanging(string value);
    partial void OnusernameChanged();
    partial void OnpasswordChanging(string value);
    partial void OnpasswordChanged();
    partial void OnemailChanging(string value);
    partial void OnemailChanged();
    partial void OnfullnameChanging(string value);
    partial void OnfullnameChanged();
    #endregion
		
		public mem_korisnici()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_username", DbType="NChar(20) NOT NULL", CanBeNull=false)]
		public string username
		{
			get
			{
				return this._username;
			}
			set
			{
				if ((this._username != value))
				{
					this.OnusernameChanging(value);
					this.SendPropertyChanging();
					this._username = value;
					this.SendPropertyChanged("username");
					this.OnusernameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_password", DbType="NChar(40) NOT NULL", CanBeNull=false)]
		public string password
		{
			get
			{
				return this._password;
			}
			set
			{
				if ((this._password != value))
				{
					this.OnpasswordChanging(value);
					this.SendPropertyChanging();
					this._password = value;
					this.SendPropertyChanged("password");
					this.OnpasswordChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_email", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string email
		{
			get
			{
				return this._email;
			}
			set
			{
				if ((this._email != value))
				{
					this.OnemailChanging(value);
					this.SendPropertyChanging();
					this._email = value;
					this.SendPropertyChanged("email");
					this.OnemailChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_fullname", DbType="NChar(30) NOT NULL", CanBeNull=false)]
		public string fullname
		{
			get
			{
				return this._fullname;
			}
			set
			{
				if ((this._fullname != value))
				{
					this.OnfullnameChanging(value);
					this.SendPropertyChanging();
					this._fullname = value;
					this.SendPropertyChanged("fullname");
					this.OnfullnameChanged();
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
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.mem_rezultati")]
	public partial class mem_rezultati : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _Id;
		
		private System.Nullable<int> _idKorisnika;
		
		private System.Nullable<int> _vreme;
		
		private System.Nullable<System.DateTime> _pocetak;
		
		private System.Nullable<System.DateTime> _kraj;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(long value);
    partial void OnIdChanged();
    partial void OnidKorisnikaChanging(System.Nullable<int> value);
    partial void OnidKorisnikaChanged();
    partial void OnvremeChanging(System.Nullable<int> value);
    partial void OnvremeChanged();
    partial void OnpocetakChanging(System.Nullable<System.DateTime> value);
    partial void OnpocetakChanged();
    partial void OnkrajChanging(System.Nullable<System.DateTime> value);
    partial void OnkrajChanged();
    #endregion
		
		public mem_rezultati()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="BigInt NOT NULL", IsPrimaryKey=true)]
		public long Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_idKorisnika", DbType="Int")]
		public System.Nullable<int> idKorisnika
		{
			get
			{
				return this._idKorisnika;
			}
			set
			{
				if ((this._idKorisnika != value))
				{
					this.OnidKorisnikaChanging(value);
					this.SendPropertyChanging();
					this._idKorisnika = value;
					this.SendPropertyChanged("idKorisnika");
					this.OnidKorisnikaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_vreme", DbType="Int")]
		public System.Nullable<int> vreme
		{
			get
			{
				return this._vreme;
			}
			set
			{
				if ((this._vreme != value))
				{
					this.OnvremeChanging(value);
					this.SendPropertyChanging();
					this._vreme = value;
					this.SendPropertyChanged("vreme");
					this.OnvremeChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_pocetak", DbType="DateTime2")]
		public System.Nullable<System.DateTime> pocetak
		{
			get
			{
				return this._pocetak;
			}
			set
			{
				if ((this._pocetak != value))
				{
					this.OnpocetakChanging(value);
					this.SendPropertyChanging();
					this._pocetak = value;
					this.SendPropertyChanged("pocetak");
					this.OnpocetakChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_kraj", DbType="DateTime2")]
		public System.Nullable<System.DateTime> kraj
		{
			get
			{
				return this._kraj;
			}
			set
			{
				if ((this._kraj != value))
				{
					this.OnkrajChanging(value);
					this.SendPropertyChanging();
					this._kraj = value;
					this.SendPropertyChanged("kraj");
					this.OnkrajChanged();
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
}
#pragma warning restore 1591
