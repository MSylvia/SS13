// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Libraryconsole_Bookmanagement : Obj_Machinery_Computer_Libraryconsole {

		public bool arcanecheckout = false;
		public string buffer_book = null;
		public string buffer_mob = null;
		public dynamic upload_category = "Fiction";
		public ByTable checkouts = new ByTable();
		public ByTable inventory = new ByTable();
		public int checkoutperiod = 5;
		public Obj_Machinery_Libraryscanner scanner = null;
		public ByTable libcomp_menu = null;
		public double? page = 1;
		public bool bibledelay = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.verb_say = "beeps";
			this.verb_ask = "beeps";
			this.verb_exclaim = "beeps";
		}

		// Function from file: lib_machines.dm
		public Obj_Machinery_Computer_Libraryconsole_Bookmanagement ( dynamic location = null, dynamic C = null ) : base( (object)(location), (object)(C) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Lang13.Bool( this.circuit ) ) {
				this.circuit.name = "circuit board (Book Inventory Management Console)";
				this.circuit.build_path = typeof(Obj_Machinery_Computer_Libraryconsole_Bookmanagement);
			}
			return;
		}

		// Function from file: lib_machines.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			Obj_Item_Weapon_Storage_Book_Bible B = null;
			Borrowbook b = null;
			dynamic b2 = null;
			dynamic b3 = null;
			string newauthor = null;
			dynamic newcategory = null;
			dynamic choice = null;
			string sqltitle = null;
			string sqlauthor = null;
			string sqlcontent = null;
			string sqlcategory = null;
			DBQuery query = null;
			dynamic orderid = null;
			string sqlid = null;
			DBQuery query2 = null;
			dynamic author = null;
			dynamic title = null;
			dynamic content = null;
			Obj_Item_Weapon_Book B2 = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				Interface13.Browse( Task13.User, null, "window=library" );
				GlobalFuncs.onclose( Task13.User, "library" );
				return null;
			}

			if ( Lang13.Bool( href_list["page"] ) && this.screenstate == 4 ) {
				this.page = String13.ParseNumber( href_list["page"] );
			}

			if ( Lang13.Bool( href_list["switchscreen"] ) ) {
				
				dynamic _a = href_list["switchscreen"]; // Was a switch-case, sorry for the mess.
				if ( _a=="0" ) {
					this.screenstate = 0;
				} else if ( _a=="1" ) {
					this.screenstate = 1;
				} else if ( _a=="2" ) {
					this.screenstate = 2;
				} else if ( _a=="3" ) {
					this.screenstate = 3;
				} else if ( _a=="4" ) {
					this.screenstate = 4;
				} else if ( _a=="5" ) {
					this.screenstate = 5;
				} else if ( _a=="6" ) {
					
					if ( !this.bibledelay ) {
						B = new Obj_Item_Weapon_Storage_Book_Bible( this.loc );

						if ( GlobalVars.ticker != null && Lang13.Bool( GlobalVars.ticker.Bible_icon_state ) && Lang13.Bool( GlobalVars.ticker.Bible_item_state ) ) {
							B.icon_state = GlobalVars.ticker.Bible_icon_state;
							B.item_state = GlobalVars.ticker.Bible_item_state;
							B.name = GlobalVars.ticker.Bible_name;
							B.deity_name = GlobalVars.ticker.Bible_deity_name;
						}
						this.bibledelay = true;
						Task13.Schedule( 60, (Task13.Closure)(() => {
							this.bibledelay = false;
							return;
						}));
					} else {
						this.say( "Bible printer currently unavailable, please wait a moment." );
					}
				} else if ( _a=="7" ) {
					this.screenstate = 7;
				}
			}

			if ( Lang13.Bool( href_list["arccheckout"] ) ) {
				
				if ( Lang13.Bool( this.emagged ) ) {
					this.arcanecheckout = true;
				}
				this.screenstate = 0;
			}

			if ( Lang13.Bool( href_list["increasetime"] ) ) {
				this.checkoutperiod += 1;
			}

			if ( Lang13.Bool( href_list["decreasetime"] ) ) {
				this.checkoutperiod -= 1;

				if ( this.checkoutperiod < 1 ) {
					this.checkoutperiod = 1;
				}
			}

			if ( Lang13.Bool( href_list["editbook"] ) ) {
				this.buffer_book = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Enter the book's title:", null, null, null, null, InputType.Str | InputType.Null ) ), 1, 1024 );
			}

			if ( Lang13.Bool( href_list["editmob"] ) ) {
				this.buffer_mob = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Enter the recipient's name:", null, null, null, null, InputType.Str | InputType.Null ) ), 1, 26 );
			}

			if ( Lang13.Bool( href_list["checkout"] ) ) {
				b = new Borrowbook();
				b.bookname = GlobalFuncs.sanitize( this.buffer_book );
				b.mobname = GlobalFuncs.sanitize( this.buffer_mob );
				b.getdate = Game13.time;
				b.duedate = Game13.time + this.checkoutperiod * 600;
				this.checkouts.Add( b );
			}

			if ( Lang13.Bool( href_list["checkin"] ) ) {
				b2 = Lang13.FindObj( href_list["checkin"] );
				this.checkouts.Remove( b2 );
			}

			if ( Lang13.Bool( href_list["delbook"] ) ) {
				b3 = Lang13.FindObj( href_list["delbook"] );
				this.inventory.Remove( b3 );
			}

			if ( Lang13.Bool( href_list["setauthor"] ) ) {
				newauthor = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Enter the author's name: ", null, null, null, null, InputType.Str | InputType.Null ) ), 1, 1024 );

				if ( Lang13.Bool( newauthor ) ) {
					this.scanner.cache.author = newauthor;
				}
			}

			if ( Lang13.Bool( href_list["setcategory"] ) ) {
				newcategory = Interface13.Input( "Choose a category: ", null, null, null, new ByTable(new object [] { "Fiction", "Non-Fiction", "Adult", "Reference", "Religion" }), InputType.Any );

				if ( Lang13.Bool( newcategory ) ) {
					this.upload_category = newcategory;
				}
			}

			if ( Lang13.Bool( href_list["upload"] ) ) {
				
				if ( this.scanner != null ) {
					
					if ( this.scanner.cache != null ) {
						choice = Interface13.Input( "Are you certain you wish to upload this title to the Archive?", null, null, null, new ByTable(new object [] { "Confirm", "Abort" }), InputType.Any );

						if ( choice == "Confirm" ) {
							GlobalFuncs.establish_db_connection();

							if ( !GlobalVars.dbcon.IsConnected() ) {
								Interface13.Alert( "Connection to Archive has been severed. Aborting." );
							} else {
								sqltitle = GlobalFuncs.sanitizeSQL( this.scanner.cache.name );
								sqlauthor = GlobalFuncs.sanitizeSQL( this.scanner.cache.author );
								sqlcontent = GlobalFuncs.sanitizeSQL( this.scanner.cache.dat );
								sqlcategory = GlobalFuncs.sanitizeSQL( this.upload_category );
								query = GlobalVars.dbcon.NewQuery( "INSERT INTO " + GlobalFuncs.format_table_name( "library" ) + " (author, title, content, category, ckey, datetime) VALUES ('" + sqlauthor + "', '" + sqltitle + "', '" + sqlcontent + "', '" + sqlcategory + "', '" + Task13.User.ckey + "', Now())" );

								if ( !query.Execute() ) {
									Task13.User.WriteMsg( query.ErrorMsg() );
								} else {
									GlobalFuncs.log_game( "" + Task13.User.name + "/" + Task13.User.key + " has uploaded the book titled " + this.scanner.cache.name + ", " + Lang13.Length( this.scanner.cache.dat ) + " signs" );
									Interface13.Alert( "Upload Complete. Uploaded title will be unavailable for printing for a short period" );
								}
							}
						}
					}
				}
			}

			if ( Lang13.Bool( href_list["orderbyid"] ) ) {
				orderid = Interface13.Input( "Enter your order:", null, null, null, null, InputType.Num | InputType.Null );

				if ( Lang13.Bool( orderid ) ) {
					
					if ( Lang13.Bool( Lang13.IsNumber( orderid ) ) ) {
						href_list["targetid"] = orderid;
					}
				}
			}

			if ( Lang13.Bool( href_list["targetid"] ) ) {
				sqlid = GlobalFuncs.sanitizeSQL( href_list["targetid"] );
				GlobalFuncs.establish_db_connection();

				if ( !GlobalVars.dbcon.IsConnected() ) {
					Interface13.Alert( "Connection to Archive has been severed. Aborting." );
				}

				if ( this.bibledelay ) {
					this.say( "Printer unavailable. Please allow a short time before attempting to print." );
				} else {
					this.bibledelay = true;
					Task13.Schedule( 60, (Task13.Closure)(() => {
						this.bibledelay = false;
						return;
					}));
					query2 = GlobalVars.dbcon.NewQuery( "SELECT * FROM " + GlobalFuncs.format_table_name( "library" ) + " WHERE id=" + sqlid + " AND isnull(deleted)" );
					query2.Execute();

					while (query2.NextRow()) {
						author = query2.item[2];
						title = query2.item[3];
						content = query2.item[4];
						B2 = new Obj_Item_Weapon_Book( this.loc );
						B2.name = "Book: " + title;
						B2.title = title;
						B2.author = author;
						B2.dat = content;
						B2.icon_state = "book" + Rand13.Int( 1, 8 );
						this.visible_message( "" + this + "'s printer hums as it produces a completely bound book. How did it do that?" );
						break;
					}
				}
			}
			this.add_fingerprint( Task13.User );
			this.updateUsrDialog();
			return null;
		}

		// Function from file: lib_machines.dm
		public override bool emag_act( dynamic user = null ) {
			
			if ( this.density && !Lang13.Bool( this.emagged ) ) {
				this.emagged = 1;
			}
			return false;
		}

		// Function from file: lib_machines.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic scanner = null;

			
			if ( A is Obj_Item_Weapon_Barcodescanner ) {
				scanner = A;
				scanner.computer = this;
				user.WriteMsg( "" + scanner + "'s associated machine has been set to " + this + "." );
				this.audible_message( "" + this + " lets out a low, short blip." );
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: lib_machines.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			string dat = null;
			Obj_Item_Weapon_Book b = null;
			Borrowbook b2 = null;
			double timetaken = 0;
			dynamic timedue = null;
			Obj_Machinery_Libraryscanner S = null;
			Browser popup = null;

			((Mob)user).set_machine( this );
			dat = "";

			switch ((int)( this.screenstate )) {
				case 0:
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";switchscreen=1'>1. View General Inventory</A><BR>" ).ToString();
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";switchscreen=2'>2. View Checked Out Inventory</A><BR>" ).ToString();
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";switchscreen=3'>3. Check out a Book</A><BR>" ).ToString();
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";switchscreen=4'>4. Connect to External Archive</A><BR>" ).ToString();
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";switchscreen=5'>5. Upload New Title to Archive</A><BR>" ).ToString();
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";switchscreen=6'>6. Print a Bible</A><BR>" ).ToString();

					if ( Lang13.Bool( this.emagged ) ) {
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";switchscreen=7'>7. Access the Forbidden Lore Vault</A><BR>" ).ToString();
					}

					if ( this.arcanecheckout ) {
						new Obj_Item_Weapon_Tome( this.loc );
						user.WriteMsg( "<span class='warning'>Your sanity barely endures the seconds spent in the vault's browsing window. The only thing to remind you of this when you stop browsing is a dusty old tome sitting on the desk. You don't really remember printing it.</span>" );
						((Ent_Static)user).visible_message( "" + user + " stares at the blank screen for a few moments, his expression frozen in fear. When he finally awakens from it, he looks a lot older.", 2 );
						this.arcanecheckout = false;
					}
					break;
				case 1:
					dat += "<H3>Inventory</H3><BR>";

					foreach (dynamic _a in Lang13.Enumerate( this.inventory, typeof(Obj_Item_Weapon_Book) )) {
						b = _a;
						
						dat += new Txt().item( b.name ).str( " <A href='?src=" ).Ref( this ).str( ";delbook=" ).Ref( b ).str( "'>(Delete)</A><BR>" ).ToString();
					}
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";switchscreen=0'>(Return to main menu)</A><BR>" ).ToString();
					break;
				case 2:
					dat += "<h3>Checked Out Books</h3><BR>";

					foreach (dynamic _b in Lang13.Enumerate( this.checkouts, typeof(Borrowbook) )) {
						b2 = _b;
						
						timetaken = Game13.time - b2.getdate;
						timetaken /= 600;
						timetaken = Num13.Floor( timetaken );
						timedue = b2.duedate - Game13.time;
						timedue /= 600;

						if ( Convert.ToDouble( timedue ) <= 0 ) {
							timedue = "<font color=red><b>(OVERDUE)</b> " + timedue + "</font>";
						} else {
							timedue = Num13.Floor( Convert.ToDouble( timedue ) );
						}
						dat += "\"" + b2.bookname + "\", Checked out to: " + b2.mobname + "<BR>--- Taken: " + timetaken + " minutes ago, Due: in " + timedue + " minutes<BR>";
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";checkin=" ).Ref( b2 ).str( "'>(Check In)</A><BR><BR>" ).ToString();
					}
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";switchscreen=0'>(Return to main menu)</A><BR>" ).ToString();
					break;
				case 3:
					dat += "<h3>Check Out a Book</h3><BR>";
					dat += "Book: " + this.buffer_book + " ";
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";editbook=1'>[Edit]</A><BR>" ).ToString();
					dat += "Recipient: " + this.buffer_mob + " ";
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";editmob=1'>[Edit]</A><BR>" ).ToString();
					dat += "Checkout Date : " + Game13.time / 600 + "<BR>";
					dat += "Due Date: " + ( Game13.time + this.checkoutperiod ) / 600 + "<BR>";
					dat += new Txt( "(Checkout Period: " ).item( this.checkoutperiod ).str( " minutes) (<A href='?src=" ).Ref( this ).str( ";increasetime=1'>+</A>/<A href='?src=" ).Ref( this ).str( ";decreasetime=1'>-</A>)" ).ToString();
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";checkout=1'>(Commit Entry)</A><BR>" ).ToString();
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";switchscreen=0'>(Return to main menu)</A><BR>" ).ToString();
					break;
				case 4:
					dat += "<h3>External Archive</h3>";
					this.build_library_menu();

					if ( !( GlobalVars.cachedbooks != null ) ) {
						dat += "<font color=red><b>ERROR</b>: Unable to contact External Archive. Please contact your system administrator for assistance.</font>";
					} else {
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";orderbyid=1'>(Order book by SS<sup>13</sup>BN)</A><BR><BR>" ).ToString();
						dat += "<table>";
						dat += "<tr><td>AUTHOR</td><td>TITLE</td><td>CATEGORY</td><td></td></tr>";
						dat += this.libcomp_menu[Num13.MaxInt( 1, Num13.MinInt( ((int)( this.page ??0 )), this.libcomp_menu.len ) )];
						dat += new Txt( "<tr><td><A href='?src=" ).Ref( this ).str( ";page=" ).item( Num13.MaxInt( 1, ((int)( ( this.page ??0) - 1 )) ) ).str( "'>&lt;&lt;&lt;&lt;</A></td> <td></td> <td></td> <td><span style='text-align:right'><A href='?src=" ).Ref( this ).str( ";page=" ).item( Num13.MinInt( this.libcomp_menu.len, ((int)( ( this.page ??0) + 1 )) ) ).str( "'>&gt;&gt;&gt;&gt;</A></span></td></tr>" ).ToString();
						dat += "</table>";
					}
					dat += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";switchscreen=0'>(Return to main menu)</A><BR>" ).ToString();
					break;
				case 5:
					dat += "<H3>Upload a New Title</H3>";

					if ( !( this.scanner != null ) ) {
						
						foreach (dynamic _c in Lang13.Enumerate( Map13.FetchInRange( null, 9 ), typeof(Obj_Machinery_Libraryscanner) )) {
							S = _c;
							
							this.scanner = S;
							break;
						}
					}

					if ( !( this.scanner != null ) ) {
						dat += "<FONT color=red>No scanner found within wireless network range.</FONT><BR>";
					} else if ( !( this.scanner.cache != null ) ) {
						dat += "<FONT color=red>No data found in scanner memory.</FONT><BR>";
					} else {
						dat += "<TT>Data marked for upload...</TT><BR>";
						dat += "<TT>Title: </TT>" + this.scanner.cache.name + "<BR>";

						if ( !Lang13.Bool( this.scanner.cache.author ) ) {
							this.scanner.cache.author = "Anonymous";
						}
						dat += new Txt( "<TT>Author: </TT><A href='?src=" ).Ref( this ).str( ";setauthor=1'>" ).item( this.scanner.cache.author ).str( "</A><BR>" ).ToString();
						dat += new Txt( "<TT>Category: </TT><A href='?src=" ).Ref( this ).str( ";setcategory=1'>" ).item( this.upload_category ).str( "</A><BR>" ).ToString();
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";upload=1'>[Upload]</A><BR>" ).ToString();
					}
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";switchscreen=0'>(Return to main menu)</A><BR>" ).ToString();
					break;
				case 7:
					dat += "<h3>Accessing Forbidden Lore Vault v 1.3</h3>";
					dat += "Are you absolutely sure you want to proceed? EldritchTomes Inc. takes no responsibilities for loss of sanity resulting from this action.<p>";
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";arccheckout=1'>Yes.</A><BR>" ).ToString();
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";switchscreen=0'>No.</A><BR>" ).ToString();
					break;
			}
			popup = new Browser( user, "library", this.name, 600, 400 );
			popup.set_content( dat );
			popup.set_title_image( ((Mob)user).browse_rsc_icon( this.icon, this.icon_state ) );
			popup.open();
			return null;
		}

		// Function from file: lib_machines.dm
		public void build_library_menu(  ) {
			double i = 0;
			dynamic C = null;
			int page = 0;

			
			if ( this.libcomp_menu != null ) {
				return;
			}
			GlobalFuncs.load_library_db_to_cache();

			if ( !( GlobalVars.cachedbooks != null ) ) {
				return;
			}
			this.libcomp_menu = new ByTable(new object [] { "" });

			foreach (dynamic _a in Lang13.IterateRange( 1, GlobalVars.cachedbooks.len )) {
				i = _a;
				
				C = GlobalVars.cachedbooks[i];
				page = Num13.Floor( i / 250 ) + 1;

				if ( this.libcomp_menu.len < page ) {
					this.libcomp_menu.len = page;
					this.libcomp_menu[page] = "";
				}
				this.libcomp_menu[page] += new Txt( "<tr><td>" ).item( C.author ).str( "</td><td>" ).item( C.title ).str( "</td><td>" ).item( C.category ).str( "</td><td><A href='?src=" ).Ref( this ).str( ";targetid=" ).item( C.id ).str( "'>[Order]</A></td></tr>\n" ).ToString();
			}
			return;
		}

	}

}