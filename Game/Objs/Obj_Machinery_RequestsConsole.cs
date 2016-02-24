// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_RequestsConsole : Obj_Machinery {

		public string department = "Unknown";
		public ByTable messages = new ByTable();
		public int departmentType = 0;
		public int newmessagepriority = 0;
		public int screen = 0;
		public bool silent = false;
		public bool hackState = false;
		public bool announcementConsole = false;
		public bool open = false;
		public bool announceAuth = false;
		public string msgVerified = "";
		public string msgStamped = "";
		public string message = "";
		public string dpt = "";
		public double? priority = -1;
		public Obj_Item_Device_Radio Radio = null;
		public string emergency = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.luminosity = 0;
			this.anchored = 1;
			this.icon = "icons/obj/terminals.dmi";
			this.icon_state = "req_comp0";
		}

		// Function from file: requests_console.dm
		public Obj_Machinery_RequestsConsole ( dynamic loc = null ) : base( (object)(loc) ) {
			this.name = new Txt().improper().item( this.department ).str( " requests console" ).ToString();
			GlobalVars.allConsoles.Add( this );

			switch ( this.departmentType ) {
				case 1:
					
					if ( !GlobalVars.req_console_assistance.Contains( "" + this.department ) ) {
						GlobalVars.req_console_assistance.Add( this.department );
					}
					break;
				case 2:
					
					if ( !GlobalVars.req_console_supplies.Contains( "" + this.department ) ) {
						GlobalVars.req_console_supplies.Add( this.department );
					}
					break;
				case 3:
					
					if ( !GlobalVars.req_console_information.Contains( "" + this.department ) ) {
						GlobalVars.req_console_information.Add( this.department );
					}
					break;
				case 4:
					
					if ( !GlobalVars.req_console_assistance.Contains( "" + this.department ) ) {
						GlobalVars.req_console_assistance.Add( this.department );
					}

					if ( !GlobalVars.req_console_supplies.Contains( "" + this.department ) ) {
						GlobalVars.req_console_supplies.Add( this.department );
					}
					break;
				case 5:
					
					if ( !GlobalVars.req_console_assistance.Contains( "" + this.department ) ) {
						GlobalVars.req_console_assistance.Add( this.department );
					}

					if ( !GlobalVars.req_console_information.Contains( "" + this.department ) ) {
						GlobalVars.req_console_information.Add( this.department );
					}
					break;
				case 6:
					
					if ( !GlobalVars.req_console_supplies.Contains( "" + this.department ) ) {
						GlobalVars.req_console_supplies.Add( this.department );
					}

					if ( !GlobalVars.req_console_information.Contains( "" + this.department ) ) {
						GlobalVars.req_console_information.Add( this.department );
					}
					break;
				case 7:
					
					if ( !GlobalVars.req_console_assistance.Contains( "" + this.department ) ) {
						GlobalVars.req_console_assistance.Add( this.department );
					}

					if ( !GlobalVars.req_console_supplies.Contains( "" + this.department ) ) {
						GlobalVars.req_console_supplies.Add( this.department );
					}

					if ( !GlobalVars.req_console_information.Contains( "" + this.department ) ) {
						GlobalVars.req_console_information.Add( this.department );
					}
					break;
			}
			this.Radio = new Obj_Item_Device_Radio( this );
			this.Radio.listening = false;
			return;
		}

		// Function from file: requests_console.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic ID = null;
			dynamic T = null;

			
			if ( A is Obj_Item_Weapon_Crowbar ) {
				
				if ( this.open ) {
					user.WriteMsg( "<span class='notice'>You close the maintenance panel.</span>" );
					this.open = false;
					this.icon_state = "req_comp0";
				} else {
					user.WriteMsg( "<span class='notice'>You open the maintenance panel.</span>" );
					this.open = true;

					if ( !this.hackState ) {
						this.icon_state = "req_comp_open";
					} else if ( this.hackState ) {
						this.icon_state = "req_comp_rewired";
					}
				}
			}

			if ( A is Obj_Item_Weapon_Screwdriver ) {
				
				if ( this.open ) {
					
					if ( !this.hackState ) {
						user.WriteMsg( "<span class='notice'>You modify the wiring.</span>" );
						this.hackState = true;
						this.icon_state = "req_comp_rewired";
					} else if ( this.hackState ) {
						user.WriteMsg( "<span class='notice'>You reset the wiring.</span>" );
						this.hackState = false;
						this.icon_state = "req_comp_open";
					}
				} else {
					user.WriteMsg( "<span class='warning'>You can't do much with that!</span>" );
				}
			}
			this.update_icon();
			ID = ((Obj_Item)A).GetID();

			if ( Lang13.Bool( ID ) ) {
				
				if ( this.screen == 9 ) {
					this.msgVerified = "<font color='green'><b>Verified by " + ID.registered_name + " (" + ID.assignment + ")</b></font>";
					this.updateUsrDialog();
				}

				if ( this.screen == 10 ) {
					
					if ( Lang13.Bool( ID.access.Contains( GlobalVars.access_RC_announce ) ) ) {
						this.announceAuth = true;
					} else {
						this.announceAuth = false;
						user.WriteMsg( "<span class='warning'>You are not authorized to send announcements!</span>" );
					}
					this.updateUsrDialog();
				}
			}

			if ( A is Obj_Item_Weapon_Stamp ) {
				
				if ( this.screen == 9 ) {
					T = A;
					this.msgStamped = "<span class='boldnotice'>Stamped with the " + T.name + "</span>";
					this.updateUsrDialog();
				}
			}
			return null;
		}

		// Function from file: requests_console.dm
		public void createmessage( dynamic source = null, string title = null, string message = null, int priority = 0 ) {
			dynamic linkedsender = null;
			dynamic sender = null;

			
			if ( source is Obj_Machinery_RequestsConsole ) {
				sender = source;
				linkedsender = new Txt( "<a href='?src=" ).Ref( this ).str( ";write=" ).item( String13.CKey( sender.department ) ).str( "'>" ).item( sender.department ).str( "</a>" ).ToString();
			} else {
				GlobalFuncs.capitalize( source );
				linkedsender = source;
			}
			GlobalFuncs.capitalize( title );

			switch ((int)( priority )) {
				case 2:
					
					if ( this.newmessagepriority < 2 ) {
						this.newmessagepriority = 2;
						this.update_icon();
					}

					if ( !this.silent ) {
						GlobalFuncs.playsound( this.loc, "sound/machines/twobeep.ogg", 50, 1 );
						this.say( title );
						this.messages.Add( "<span class='bad'>High Priority</span><BR><b>From:</b> " + linkedsender + "<BR>" + message );
					}
					break;
				case 3:
					
					if ( this.newmessagepriority < 3 ) {
						this.newmessagepriority = 3;
						this.update_icon();
					}
					GlobalFuncs.playsound( this.loc, "sound/machines/twobeep.ogg", 50, 1 );
					this.say( title );
					this.messages.Add( "<span class='bad'>!!!Extreme Priority!!!</span><BR><b>From:</b> " + linkedsender + "<BR>" + message );
					break;
				default:
					
					if ( this.newmessagepriority < 1 ) {
						this.newmessagepriority = 1;
						this.update_icon();
					}

					if ( !this.silent ) {
						GlobalFuncs.playsound( this.loc, "sound/machines/twobeep.ogg", 50, 1 );
						this.say( title );
					}
					this.messages.Add( "<b>From:</b> " + linkedsender + "<BR>" + message );
					break;
			}
			this.SetLuminosity( 2 );
			return;
		}

		// Function from file: requests_console.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			string new_message = null;
			string new_message2 = null;
			double? radio_freq = null;
			string log_msg = null;
			string sending = null;
			bool pass = false;
			Obj_Machinery_MessageServer MS = null;
			double? radio_freq2 = null;
			string authentic = null;
			string alert = null;
			Obj_Machinery_RequestsConsole Console = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );
			this.add_fingerprint( Task13.User );

			if ( Lang13.Bool( GlobalFuncs.reject_bad_text( href_list["write"] ) ) ) {
				this.dpt = String13.CKey( href_list["write"] );
				new_message = String13.SubStr( GlobalFuncs.reject_bad_text( Interface13.Input( Task13.User, "Write your message:", "Awaiting Input", "", null, InputType.Any ) ), 1, 1024 );

				if ( Lang13.Bool( new_message ) ) {
					this.message = new_message;
					this.screen = 9;

					if ( ( String13.ParseNumber( href_list["priority"] ) ??0) < 2 ) {
						this.priority = -1;
					} else {
						this.priority = String13.ParseNumber( href_list["priority"] );
					}
				} else {
					this.dpt = "";
					this.msgVerified = "";
					this.msgStamped = "";
					this.screen = 0;
					this.priority = -1;
				}
			}

			if ( Lang13.Bool( href_list["writeAnnouncement"] ) ) {
				new_message2 = String13.SubStr( GlobalFuncs.reject_bad_text( Interface13.Input( Task13.User, "Write your message:", "Awaiting Input", "", null, InputType.Any ) ), 1, 1024 );

				if ( Lang13.Bool( new_message2 ) ) {
					this.message = new_message2;

					if ( ( String13.ParseNumber( href_list["priority"] ) ??0) < 2 ) {
						this.priority = -1;
					} else {
						this.priority = String13.ParseNumber( href_list["priority"] );
					}
				} else {
					this.message = "";
					this.announceAuth = false;
					this.screen = 0;
				}
			}

			if ( Lang13.Bool( href_list["sendAnnouncement"] ) ) {
				
				if ( !this.announcementConsole ) {
					return null;
				}
				GlobalFuncs.minor_announce( this.message, "" + this.department + " Announcement:" );
				GlobalVars.news_network.SubmitArticle( this.message, this.department, "Station Announcements", null );
				GlobalFuncs.log_say( "" + GlobalFuncs.key_name( Task13.User ) + " has made a station announcement: " + this.message );
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( Task13.User ) + " has made a station announcement." );
				this.announceAuth = false;
				this.message = "";
				this.screen = 0;
			}

			if ( Lang13.Bool( href_list["emergency"] ) ) {
				
				if ( !Lang13.Bool( this.emergency ) ) {
					
					switch ((int?)( String13.ParseNumber( href_list["emergency"] ) )) {
						case 1:
							radio_freq = GlobalVars.SEC_FREQ;
							this.emergency = "Security";
							break;
						case 2:
							radio_freq = GlobalVars.ENG_FREQ;
							this.emergency = "Engineering";
							break;
						case 3:
							radio_freq = GlobalVars.MED_FREQ;
							this.emergency = "Medical";
							break;
					}

					if ( Lang13.Bool( radio_freq ) ) {
						this.Radio.set_frequency( radio_freq );
						this.Radio.talk_into( this, "" + this.emergency + " emergency in " + this.department + "!!", radio_freq );
						this.update_icon();
						Task13.Schedule( 3000, (Task13.Closure)(() => {
							this.emergency = null;
							this.update_icon();
							return;
						}));
					}
				}
			}

			if ( Lang13.Bool( href_list["department"] ) && Lang13.Bool( this.message ) ) {
				log_msg = this.message;
				sending = this.message;
				sending += "<br>";

				if ( Lang13.Bool( this.msgVerified ) ) {
					sending += this.msgVerified;
					sending += "<br>";
				}

				if ( Lang13.Bool( this.msgStamped ) ) {
					sending += this.msgStamped;
					sending += "<br>";
				}
				this.screen = 7;

				if ( Lang13.Bool( sending ) ) {
					pass = false;

					foreach (dynamic _b in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_MessageServer) )) {
						MS = _b;
						

						if ( !MS.active ) {
							continue;
						}
						MS.send_rc_message( href_list["department"], this.department, log_msg, this.msgStamped, this.msgVerified, this.priority );
						pass = true;
					}

					if ( pass ) {
						radio_freq2 = 0;

						dynamic _c = href_list["department"]; // Was a switch-case, sorry for the mess.
						if ( _c=="bridge" ) {
							radio_freq2 = GlobalVars.COMM_FREQ;
						} else if ( _c=="medbay" ) {
							radio_freq2 = GlobalVars.MED_FREQ;
						} else if ( _c=="science" ) {
							radio_freq2 = GlobalVars.SCI_FREQ;
						} else if ( _c=="engineering" ) {
							radio_freq2 = GlobalVars.ENG_FREQ;
						} else if ( _c=="security" ) {
							radio_freq2 = GlobalVars.SEC_FREQ;
						} else if ( _c=="cargobay" ) {
							radio_freq2 = GlobalVars.SUPP_FREQ;
						}
						this.Radio.set_frequency( radio_freq2 );
						authentic = null;

						if ( Lang13.Bool( this.msgVerified ) || Lang13.Bool( this.msgStamped ) ) {
							authentic = " (Authenticated)";
						}
						alert = "";

						foreach (dynamic _e in Lang13.Enumerate( GlobalVars.allConsoles, typeof(Obj_Machinery_RequestsConsole) )) {
							Console = _e;
							

							if ( String13.CKey( Console.department ) == String13.CKey( href_list["department"] ) ) {
								
								switch ((int?)( this.priority )) {
									case 2:
										alert = "PRIORITY Alert in " + this.department + authentic;
										Console.createmessage( this, alert, sending, 2 );
										break;
									case 3:
										alert = "EXTREME PRIORITY Alert from " + this.department + authentic;
										Console.createmessage( this, alert, sending, 3 );
										break;
									default:
										alert = "Message from " + this.department + authentic;
										Console.createmessage( this, alert, sending, 1 );
										break;
								}
								this.screen = 6;
								Console.SetLuminosity( 2 );
							}
						}

						if ( Lang13.Bool( radio_freq2 ) ) {
							this.Radio.talk_into( this, "" + alert + ": <i>" + this.message + "</i>", radio_freq2 );
						}

						switch ((int?)( this.priority )) {
							case 2:
								this.messages.Add( "<span class='bad'>High Priority</span><BR><b>To:</b> " + this.dpt + "<BR>" + sending );
								break;
							default:
								this.messages.Add( "<b>To: " + this.dpt + "</b><BR>" + sending );
								break;
						}
					} else {
						this.say( "NOTICE: No server detected!" );
					}
				}
			}

			switch ((int?)( String13.ParseNumber( href_list["setScreen"] ) )) {
				case null:
					
					break;
				case 1:
					this.screen = 1;
					break;
				case 2:
					this.screen = 2;
					break;
				case 3:
					this.screen = 3;
					break;
				case 5:
					this.screen = 5;
					break;
				case 6:
					this.screen = 6;
					break;
				case 7:
					this.screen = 7;
					break;
				case 8:
					this.screen = 8;
					break;
				case 9:
					this.screen = 9;
					break;
				case 10:
					
					if ( !this.announcementConsole ) {
						return null;
					}
					this.screen = 10;
					break;
				default:
					this.dpt = "";
					this.msgVerified = "";
					this.msgStamped = "";
					this.message = "";
					this.priority = -1;
					this.screen = 0;
					break;
			}

			dynamic _h = href_list["setSilent"]; // Was a switch-case, sorry for the mess.
			if ( _h==null ) {
				
			} else if ( _h=="1" ) {
				this.silent = true;
			} else {
				this.silent = false;
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: requests_console.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			string dat = null;
			dynamic dpt = null;
			dynamic dpt2 = null;
			dynamic dpt3 = null;
			Obj_Machinery_RequestsConsole Console = null;
			string messageComposite = null;
			dynamic msg = null;
			Browser popup = null;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), b, c ) ) ) {
				return null;
			}
			dat = "";

			if ( !this.open ) {
				
				switch ((int)( this.screen )) {
					case 1:
						dat += "Which department do you need assistance from?<BR><BR>";
						dat += "<table width='100%'>";

						foreach (dynamic _a in Lang13.Enumerate( GlobalVars.req_console_assistance )) {
							dpt = _a;
							

							if ( dpt != this.department ) {
								dat += "<tr>";
								dat += "<td width='55%'>" + dpt + "</td>";
								dat += new Txt( "<td width='45%'><A href='?src=" ).Ref( this ).str( ";write=" ).item( String13.CKey( dpt ) ).str( "'>Normal</A> <A href='?src=" ).Ref( this ).str( ";write=" ).item( String13.CKey( dpt ) ).str( ";priority=2'>High</A>" ).ToString();

								if ( this.hackState ) {
									dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";write=" ).item( String13.CKey( dpt ) ).str( ";priority=3'>EXTREME</A>" ).ToString();
								}
								dat += "</td>";
								dat += "</tr>";
							}
						}
						dat += "</table>";
						dat += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";setScreen=0'><< Back</A><BR>" ).ToString();
						break;
					case 2:
						dat += "Which department do you need supplies from?<BR><BR>";
						dat += "<table width='100%'>";

						foreach (dynamic _b in Lang13.Enumerate( GlobalVars.req_console_supplies )) {
							dpt2 = _b;
							

							if ( dpt2 != this.department ) {
								dat += "<tr>";
								dat += "<td width='55%'>" + dpt2 + "</td>";
								dat += new Txt( "<td width='45%'><A href='?src=" ).Ref( this ).str( ";write=" ).item( String13.CKey( dpt2 ) ).str( "'>Normal</A> <A href='?src=" ).Ref( this ).str( ";write=" ).item( String13.CKey( dpt2 ) ).str( ";priority=2'>High</A>" ).ToString();

								if ( this.hackState ) {
									dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";write=" ).item( String13.CKey( dpt2 ) ).str( ";priority=3'>EXTREME</A>" ).ToString();
								}
								dat += "</td>";
								dat += "</tr>";
							}
						}
						dat += "</table>";
						dat += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";setScreen=0'><< Back</A><BR>" ).ToString();
						break;
					case 3:
						dat += "Which department would you like to send information to?<BR><BR>";
						dat += "<table width='100%'>";

						foreach (dynamic _c in Lang13.Enumerate( GlobalVars.req_console_information )) {
							dpt3 = _c;
							

							if ( dpt3 != this.department ) {
								dat += "<tr>";
								dat += "<td width='55%'>" + dpt3 + "</td>";
								dat += new Txt( "<td width='45%'><A href='?src=" ).Ref( this ).str( ";write=" ).item( String13.CKey( dpt3 ) ).str( "'>Normal</A> <A href='?src=" ).Ref( this ).str( ";write=" ).item( String13.CKey( dpt3 ) ).str( ";priority=2'>High</A>" ).ToString();

								if ( this.hackState ) {
									dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";write=" ).item( String13.CKey( dpt3 ) ).str( ";priority=3'>EXTREME</A>" ).ToString();
								}
								dat += "</td>";
								dat += "</tr>";
							}
						}
						dat += "</table>";
						dat += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";setScreen=0'><< Back</A><BR>" ).ToString();
						break;
					case 6:
						dat += "<span class='good'>Message sent.</span><BR><BR>";
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";setScreen=0'>Continue</A><BR>" ).ToString();
						break;
					case 7:
						dat += "<span class='bad'>An error occurred.</span><BR><BR>";
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";setScreen=0'>Continue</A><BR>" ).ToString();
						break;
					case 8:
						
						foreach (dynamic _d in Lang13.Enumerate( GlobalVars.allConsoles, typeof(Obj_Machinery_RequestsConsole) )) {
							Console = _d;
							

							if ( Console.department == this.department ) {
								Console.newmessagepriority = 0;
								Console.update_icon();
								Console.SetLuminosity( 1 );
							}
						}
						this.newmessagepriority = 0;
						this.update_icon();
						messageComposite = "";

						foreach (dynamic _e in Lang13.Enumerate( this.messages )) {
							msg = _e;
							
							messageComposite = "<div class='block'>" + msg + "</div>" + messageComposite;
						}
						dat += messageComposite;
						dat += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";setScreen=0'><< Back to Main Menu</A><BR>" ).ToString();
						break;
					case 9:
						dat += "<B>Message Authentication</B><BR><BR>";
						dat += "<b>Message for " + this.dpt + ": </b>" + this.message + "<BR><BR>";
						dat += "<div class='notice'>You may authenticate your message now by scanning your ID or your stamp</div><BR>";
						dat += "<b>Validated by:</b> " + ( Lang13.Bool( this.msgVerified ) ? this.msgVerified : "<i>Not Validated</i>" ) + "<br>";
						dat += "<b>Stamped by:</b> " + ( Lang13.Bool( this.msgStamped ) ? this.msgStamped : "<i>Not Stamped</i>" ) + "<br><br>";
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";department=" ).item( this.dpt ).str( "'>Send Message</A><BR>" ).ToString();
						dat += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";setScreen=0'><< Discard Message</A><BR>" ).ToString();
						break;
					case 10:
						dat += "<h3>Station-wide Announcement</h3>";

						if ( this.announceAuth ) {
							dat += "<div class='notice'>Authentication accepted</div><BR>";
						} else {
							dat += "<div class='notice'>Swipe your card to authenticate yourself</div><BR>";
						}
						dat += "<b>Message: </b>" + ( Lang13.Bool( this.message ) ? this.message : "<i>No Message</i>" ) + "<BR>";
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";writeAnnouncement=1'>" ).item( ( Lang13.Bool( this.message ) ? "Edit" : "Write" ) ).str( " Message</A><BR><BR>" ).ToString();

						if ( ( this.announceAuth || Lang13.Bool( GlobalFuncs.IsAdminGhost( a ) ) ) && Lang13.Bool( this.message ) ) {
							dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";sendAnnouncement=1'>Announce Message</A><BR>" ).ToString();
						} else {
							dat += "<span class='linkOff'>Announce Message</span><BR>";
						}
						dat += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";setScreen=0'><< Back</A><BR>" ).ToString();
						break;
					default:
						this.screen = 0;
						this.announceAuth = false;

						if ( this.newmessagepriority == 1 ) {
							dat += "<div class='notice'>There are new messages</div><BR>";
						}

						if ( this.newmessagepriority == 2 ) {
							dat += "<div class='notice'>There are new <b>PRIORITY</b> messages</div><BR>";
						}

						if ( this.newmessagepriority == 3 ) {
							dat += "<div class='notice'>There are new <b>EXTREME PRIORITY</b> messages</div><BR>";
						}
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";setScreen=8'>View Messages</A><BR><BR>" ).ToString();
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";setScreen=1'>Request Assistance</A><BR>" ).ToString();
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";setScreen=2'>Request Supplies</A><BR>" ).ToString();
						dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";setScreen=3'>Relay Anonymous Information</A><BR><BR>" ).ToString();

						if ( !Lang13.Bool( this.emergency ) ) {
							dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";emergency=1'>Emergency: Security</A><BR>" ).ToString();
							dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";emergency=2'>Emergency: Engineering</A><BR>" ).ToString();
							dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";emergency=3'>Emergency: Medical</A><BR><BR>" ).ToString();
						} else {
							dat += "<B><font color='red'>" + this.emergency + " has been dispatched to this location.</font></B><BR><BR>";
						}

						if ( this.announcementConsole ) {
							dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";setScreen=10'>Send Station-wide Announcement</A><BR><BR>" ).ToString();
						}

						if ( this.silent ) {
							dat += new Txt( "Speaker <A href='?src=" ).Ref( this ).str( ";setSilent=0'>OFF</A>" ).ToString();
						} else {
							dat += new Txt( "Speaker <A href='?src=" ).Ref( this ).str( ";setSilent=1'>ON</A>" ).ToString();
						}
						break;
				}
				popup = new Browser( a, "req_console", "" + this.department + " Requests Console", 450, 440 );
				popup.set_content( dat );
				popup.set_title_image( ((Mob)a).browse_rsc_icon( this.icon, this.icon_state ) );
				popup.open();
			}
			return null;
		}

		// Function from file: requests_console.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( this.open ) {
				
				if ( !this.hackState ) {
					this.icon_state = "req_comp_open";
				} else {
					this.icon_state = "req_comp_rewired";
				}
			} else if ( ( this.stat & 2 ) != 0 ) {
				
				if ( this.icon_state != "req_comp_off" ) {
					this.icon_state = "req_comp_off";
				}
			} else if ( Lang13.Bool( this.emergency ) || this.newmessagepriority == 3 ) {
				this.icon_state = "req_comp3";
			} else if ( this.newmessagepriority == 2 ) {
				this.icon_state = "req_comp2";
			} else if ( this.newmessagepriority == 1 ) {
				this.icon_state = "req_comp1";
			} else {
				this.icon_state = "req_comp0";
			}
			return false;
		}

		// Function from file: requests_console.dm
		public override void power_change(  ) {
			base.power_change();
			this.update_icon();
			return;
		}

	}

}