// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Telecomms : Obj_Machinery {

		public string temp = "";
		public ByTable links = new ByTable();
		public int traffic = 0;
		public int netspeed = 5;
		public ByTable autolinkers = new ByTable();
		public string id = "NULL";
		public string network = "NULL";
		public ByTable freq_listening = new ByTable();
		public int machinetype = 0;
		public bool toggled = true;
		public bool on = true;
		public bool long_range_link = false;
		public string circuitboard = null;
		public bool v_hide = false;
		public int? listening_level = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/machines/telecomms.dmi";
		}

		// Function from file: telecomunications.dm
		public Obj_Machinery_Telecomms ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic position = null;

			GlobalVars.telecomms_list.Add( this );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( !Lang13.Bool( this.listening_level ) ) {
				position = GlobalFuncs.get_turf( this );
				this.listening_level = Lang13.IntNullable( position.z );
			}
			return;
		}

		// Function from file: telecomunications.dm
		public override double emp_act( int severity = 0 ) {
			double duration = 0;

			
			if ( Rand13.PercentChance( ((int)( 100 / severity )) ) ) {
				
				if ( !( ( this.stat & 16 ) != 0 ) ) {
					this.stat |= 16;
					duration = 3000 / severity;
					Task13.Schedule( Rand13.Int( ((int)( duration - 20 )), ((int)( duration + 20 )) ), (Task13.Closure)(() => {
						this.stat &= 65519;
						return;
					}));
				}
			}
			base.emp_act( severity );
			return 0;
		}

		// Function from file: telecomunications.dm
		public override int? process( dynamic seconds = null ) {
			this.update_power();
			this.update_icon();

			if ( this.traffic > 0 ) {
				this.traffic -= this.netspeed;
			}
			return null;
		}

		// Function from file: telecomunications.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( this.on ) {
				
				if ( Lang13.Bool( this.panel_open ) ) {
					this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + "_o";
				} else {
					this.icon_state = Lang13.Initial( this, "icon_state" );
				}
			} else if ( Lang13.Bool( this.panel_open ) ) {
				this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + "_o_off";
			} else {
				this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + "_off";
			}
			return false;
		}

		// Function from file: telecomunications.dm
		public override dynamic Destroy(  ) {
			Obj_Machinery_Telecomms comm = null;

			GlobalVars.telecomms_list.Remove( this );

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.telecomms_list, typeof(Obj_Machinery_Telecomms) )) {
				comm = _a;
				
				comm.links.Remove( this );
			}
			this.links = new ByTable();
			return base.Destroy();
		}

		// Function from file: telecomunications.dm
		public override void initialize(  ) {
			Obj_Machinery_Telecomms T = null;
			Obj_Machinery_Telecomms T2 = null;

			
			if ( this.autolinkers.len != 0 ) {
				
				if ( !this.long_range_link ) {
					
					foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.ultra_range( 20, this, true ), typeof(Obj_Machinery_Telecomms) )) {
						T = _a;
						
						this.add_link( T );
					}
				} else {
					
					foreach (dynamic _b in Lang13.Enumerate( GlobalVars.telecomms_list, typeof(Obj_Machinery_Telecomms) )) {
						T2 = _b;
						
						this.add_link( T2 );
					}
				}
			}
			return;
		}

		// Function from file: machine_interactions.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			dynamic P = null;
			string newid = null;
			string newnet = null;
			Obj_Machinery_Telecomms T = null;
			dynamic newfreq = null;
			double? x = null;
			Obj_Machinery_Telecomms T2 = null;
			Obj_Machinery_Telecomms T3 = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}

			if ( !( Task13.User is Mob_Living_Silicon ) ) {
				
				if ( !( Task13.User.get_active_hand() is Obj_Item_Device_Multitool ) ) {
					return null;
				}
			}
			P = this.get_multitool( Task13.User );

			if ( Lang13.Bool( href_list["input"] ) ) {
				
				dynamic _b = href_list["input"]; // Was a switch-case, sorry for the mess.
				if ( _b=="toggle" ) {
					this.toggled = !this.toggled;
					this.temp = "<font color = #666633>-% " + this + " has been " + ( this.toggled ? "activated" : "deactivated" ) + ".</font color>";
					this.update_power();
				} else if ( _b=="id" ) {
					newid = String13.SubStr( GlobalFuncs.reject_bad_text( Interface13.Input( Task13.User, "Specify the new ID for this machine", this, this.id, null, InputType.Str | InputType.Null ) ), 1, 1024 );

					if ( Lang13.Bool( newid ) && this.canAccess( Task13.User ) ) {
						this.id = newid;
						this.temp = "<font color = #666633>-% New ID assigned: \"" + this.id + "\" %-</font color>";
					}
				} else if ( _b=="network" ) {
					newnet = GlobalFuncs.stripped_input( Task13.User, "Specify the new network for this machine. This will break all current links.", this, this.network );

					if ( Lang13.Bool( newnet ) && this.canAccess( Task13.User ) ) {
						
						if ( Lang13.Length( newnet ) > 15 ) {
							this.temp = "<font color = #666633>-% Too many characters in new network tag %-</font color>";
						} else {
							
							foreach (dynamic _a in Lang13.Enumerate( this.links, typeof(Obj_Machinery_Telecomms) )) {
								T = _a;
								
								T.links.Remove( this );
							}
							this.network = newnet;
							this.links = new ByTable();
							this.temp = "<font color = #666633>-% New network tag assigned: \"" + this.network + "\" %-</font color>";
						}
					}
				} else if ( _b=="freq" ) {
					newfreq = Interface13.Input( Task13.User, "Specify a new frequency to filter (GHz). Decimals assigned automatically.", this, this.network, null, InputType.Num | InputType.Null );

					if ( Lang13.Bool( newfreq ) && this.canAccess( Task13.User ) ) {
						
						if ( String13.FindIgnoreCase( String13.NumberToString( Convert.ToDouble( newfreq ) ), ".", 1, 0 ) != 0 ) {
							newfreq *= 10;
						}

						if ( newfreq == GlobalVars.SYND_FREQ ) {
							this.temp = "<font color = #FF0000>-% Error: Interference preventing filtering frequency: \"" + newfreq + " GHz\" %-</font color>";
						} else if ( !this.freq_listening.Contains( newfreq ) && Convert.ToDouble( newfreq ) < 10000 ) {
							this.freq_listening.Add( newfreq );
							this.temp = "<font color = #666633>-% New frequency filter assigned: \"" + newfreq + " GHz\" %-</font color>";
						}
					}
				}
			}

			if ( Lang13.Bool( href_list["delete"] ) ) {
				x = String13.ParseNumber( href_list["delete"] );
				this.temp = "<font color = #666633>-% Removed frequency filter " + x + " %-</font color>";
				this.freq_listening.Remove( x );
			}

			if ( Lang13.Bool( href_list["unlink"] ) ) {
				
				if ( ( String13.ParseNumber( href_list["unlink"] ) ??0) <= Lang13.Length( this.links ) ) {
					T2 = this.links[String13.ParseNumber( href_list["unlink"] )];

					if ( T2 != null ) {
						this.temp = new Txt( "<font color = #666633>-% Removed " ).Ref( T2 ).str( " " ).item( T2.name ).str( " from linked entities. %-</font color>" ).ToString();

						if ( T2.links != null ) {
							T2.links.Remove( this );
						}
						this.links.Remove( T2 );
					} else {
						this.temp = "<font color = #666633>-% Unable to locate machine to unlink from, try again. %-</font color>";
					}
				}
			}

			if ( Lang13.Bool( href_list["link"] ) ) {
				
				if ( Lang13.Bool( P ) ) {
					T3 = P.buffer;

					if ( T3 is Obj_Machinery_Telecomms && T3 != this ) {
						
						if ( !T3.links.Contains( this ) ) {
							T3.links.Add( this );
						}

						if ( !this.links.Contains( T3 ) ) {
							this.links.Add( T3 );
						}
						this.temp = new Txt( "<font color = #666633>-% Successfully linked with " ).Ref( T3 ).str( " " ).item( T3.name ).str( " %-</font color>" ).ToString();
					} else {
						this.temp = "<font color = #666633>-% Unable to acquire buffer %-</font color>";
					}
				}
			}

			if ( Lang13.Bool( href_list["buffer"] ) ) {
				P.buffer = this;
				this.temp = new Txt( "<font color = #666633>-% Successfully stored " ).Ref( P.buffer ).str( " " ).item( P.buffer.name ).str( " in buffer %-</font color>" ).ToString();
			}

			if ( Lang13.Bool( href_list["flush"] ) ) {
				this.temp = "<font color = #666633>-% Buffer successfully flushed. %-</font color>";
				P.buffer = null;
			}
			this.Options_Topic( href, href_list );
			Task13.User.set_machine( this );
			this.updateUsrDialog();
			return null;
		}

		// Function from file: telecomunications.dm
		public void update_power(  ) {
			
			if ( this.toggled ) {
				
				if ( ( this.stat & 19 ) != 0 ) {
					this.on = false;
				} else {
					this.on = true;
				}
			} else {
				this.on = false;
			}
			return;
		}

		// Function from file: telecomunications.dm
		public void add_link( Obj_Machinery_Telecomms T = null ) {
			dynamic position = null;
			dynamic T_position = null;
			dynamic x = null;

			position = GlobalFuncs.get_turf( this );
			T_position = GlobalFuncs.get_turf( T );

			if ( position.z == T_position.z || this.long_range_link && T.long_range_link ) {
				
				if ( this != T ) {
					
					foreach (dynamic _a in Lang13.Enumerate( this.autolinkers )) {
						x = _a;
						

						if ( T.autolinkers.Contains( x ) ) {
							this.links.Or( T );
							break;
						}
					}
				}
			}
			return;
		}

		// Function from file: telecomunications.dm
		public bool is_freq_listening( Signal signal = null ) {
			
			if ( !( signal != null ) ) {
				return false;
			}

			if ( this.freq_listening.Contains( signal.frequency ) || !( this.freq_listening.len != 0 ) ) {
				return true;
			} else {
				return false;
			}
		}

		// Function from file: telecomunications.dm
		public virtual void receive_information( Signal signal = null, Obj_Machinery_Telecomms machine_from = null ) {
			Lang13.SuperCall( signal, machine_from );
			return;
		}

		// Function from file: telecomunications.dm
		public void relay_direct_information( Signal signal = null, Obj_Machinery_Telecomms machine = null ) {
			machine.receive_information( signal, this );
			return;
		}

		// Function from file: telecomunications.dm
		public int? relay_information( Signal signal = null, dynamic filter = null, bool? copysig = null, int? amount = null ) {
			amount = amount ?? 20;

			int? send_count = null;
			int netlag = 0;
			Obj_Machinery_Telecomms machine = null;
			Signal copy = null;

			
			if ( !this.on ) {
				return null;
			}
			send_count = 0;
			netlag = Num13.Floor( this.traffic / 50 );

			if ( netlag > Convert.ToDouble( signal.data["slow"] ) ) {
				signal.data["slow"] = netlag;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.links, typeof(Obj_Machinery_Telecomms) )) {
				machine = _a;
				

				if ( Lang13.Bool( filter ) && !Lang13.Bool( ((dynamic)Lang13.FindClass( filter )).IsInstanceOfType( machine ) ) ) {
					continue;
				}

				if ( !machine.on ) {
					continue;
				}

				if ( Lang13.Bool( amount ) && ( send_count ??0) >= ( amount ??0) ) {
					break;
				}

				if ( machine.loc.z != this.listening_level ) {
					
					if ( !this.long_range_link && !machine.long_range_link ) {
						continue;
					}
				}
				copy = new Signal();

				if ( copysig == true ) {
					copy.transmission_method = 2;
					copy.frequency = signal.frequency;
					copy.data = new ByTable()
						.Set( "mob", signal.data["mob"] )
						.Set( "mobtype", signal.data["mobtype"] )
						.Set( "realname", signal.data["realname"] )
						.Set( "name", signal.data["name"] )
						.Set( "job", signal.data["job"] )
						.Set( "key", signal.data["key"] )
						.Set( "vmask", signal.data["vmask"] )
						.Set( "compression", signal.data["compression"] )
						.Set( "message", signal.data["message"] )
						.Set( "radio", signal.data["radio"] )
						.Set( "slow", signal.data["slow"] )
						.Set( "traffic", signal.data["traffic"] )
						.Set( "type", signal.data["type"] )
						.Set( "server", signal.data["server"] )
						.Set( "reject", signal.data["reject"] )
						.Set( "level", signal.data["level"] )
						.Set( "spans", signal.data["spans"] )
						.Set( "verb_say", signal.data["verb_say"] )
						.Set( "verb_ask", signal.data["verb_ask"] )
						.Set( "verb_exclaim", signal.data["verb_exclaim"] )
						.Set( "verb_yell", signal.data["verb_yell"] )
					;

					if ( !Lang13.Bool( signal.data["original"] ) ) {
						copy.data["original"] = signal;
					} else {
						copy.data["original"] = signal.data["original"];
					}
				} else {
					copy = null;
				}
				send_count++;

				if ( machine.is_freq_listening( signal ) ) {
					machine.traffic++;
				}

				if ( copysig == true && copy != null ) {
					machine.receive_information( copy, this );
				} else {
					machine.receive_information( signal, this );
				}
			}

			if ( ( send_count ??0) > 0 && this.is_freq_listening( signal ) ) {
				this.traffic++;
			}
			return send_count;
		}

		// Function from file: machine_interactions.dm
		public bool canAccess( Mob user = null ) {
			
			if ( user is Mob_Living_Silicon || Map13.GetDistance( user, this ) <= 1 ) {
				return true;
			}
			return false;
		}

		// Function from file: machine_interactions.dm
		public virtual void Options_Topic( string href = null, ByTable href_list = null ) {
			return;
		}

		// Function from file: machine_interactions.dm
		public virtual string Options_Menu(  ) {
			return "";
		}

		// Function from file: machine_interactions.dm
		public dynamic get_multitool( dynamic user = null ) {
			dynamic P = null;
			dynamic U = null;

			P = null;

			if ( !( user is Mob_Living_Silicon ) && ((Mob)user).get_active_hand() is Obj_Item_Device_Multitool ) {
				P = ((Mob)user).get_active_hand();
			} else if ( user is Mob_Living_Silicon_Ai ) {
				U = user;
				P = U.aiMulti;
			} else if ( user is Mob_Living_Silicon_Robot && Map13.GetDistance( user, this ) <= 1 ) {
				
				if ( ((Mob)user).get_active_hand() is Obj_Item_Device_Multitool ) {
					P = ((Mob)user).get_active_hand();
				}
			}
			return P;
		}

		// Function from file: machine_interactions.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			dynamic P = null;
			string dat = null;
			int i = 0;
			Obj_Machinery_Telecomms T = null;
			dynamic x = null;
			dynamic T2 = null;

			
			if ( !( a is Mob_Living_Silicon ) ) {
				
				if ( !( ((Mob)a).get_active_hand() is Obj_Item_Device_Multitool ) ) {
					return null;
				}
			}

			if ( ( this.stat & 3 ) != 0 ) {
				return null;
			}
			P = this.get_multitool( a );
			((Mob)a).set_machine( this );
			dat = "<font face = \"Courier\"><HEAD><TITLE>" + this.name + "</TITLE></HEAD><center><H3>" + this.name + " Access</H3></center>";
			dat += "<br>" + this.temp + "<br>";
			dat += new Txt( "<br>Power Status: <a href='?src=" ).Ref( this ).str( ";input=toggle'>" ).item( ( this.toggled ? "On" : "Off" ) ).str( "</a>" ).ToString();

			if ( this.on && this.toggled ) {
				
				if ( this.id != "" && Lang13.Bool( this.id ) ) {
					dat += new Txt( "<br>Identification String: <a href='?src=" ).Ref( this ).str( ";input=id'>" ).item( this.id ).str( "</a>" ).ToString();
				} else {
					dat += new Txt( "<br>Identification String: <a href='?src=" ).Ref( this ).str( ";input=id'>NULL</a>" ).ToString();
				}
				dat += new Txt( "<br>Network: <a href='?src=" ).Ref( this ).str( ";input=network'>" ).item( this.network ).str( "</a>" ).ToString();
				dat += "<br>Prefabrication: " + ( this.autolinkers.len != 0 ? "TRUE" : "FALSE" );

				if ( this.v_hide ) {
					dat += "<br>Shadow Link: ACTIVE</a>";
				}
				dat += this.Options_Menu();
				dat += "<br>Linked Network Entities: <ol>";
				i = 0;

				foreach (dynamic _a in Lang13.Enumerate( this.links, typeof(Obj_Machinery_Telecomms) )) {
					T = _a;
					
					i++;

					if ( T.v_hide && !this.v_hide ) {
						continue;
					}
					dat += new Txt( "<li>" ).Ref( T ).str( " " ).item( T.name ).str( " (" ).item( T.id ).str( ")  <a href='?src=" ).Ref( this ).str( ";unlink=" ).item( i ).str( "'>[X]</a></li>" ).ToString();
				}
				dat += "</ol>";
				dat += "<br>Filtering Frequencies: ";
				i = 0;

				if ( Lang13.Length( this.freq_listening ) != 0 ) {
					
					foreach (dynamic _b in Lang13.Enumerate( this.freq_listening )) {
						x = _b;
						
						i++;

						if ( i < Lang13.Length( this.freq_listening ) ) {
							dat += new Txt().item( GlobalFuncs.format_frequency( x ) ).str( " GHz<a href='?src=" ).Ref( this ).str( ";delete=" ).item( x ).str( "'>[X]</a>; " ).ToString();
						} else {
							dat += new Txt().item( GlobalFuncs.format_frequency( x ) ).str( " GHz<a href='?src=" ).Ref( this ).str( ";delete=" ).item( x ).str( "'>[X]</a>" ).ToString();
						}
					}
				} else {
					dat += "NONE";
				}
				dat += new Txt( "<br>  <a href='?src=" ).Ref( this ).str( ";input=freq'>[Add Filter]</a>" ).ToString();
				dat += "<hr>";

				if ( Lang13.Bool( P ) ) {
					T2 = P.buffer;

					if ( T2 is Obj_Machinery_Telecomms ) {
						dat += new Txt( "<br><br>MULTITOOL BUFFER: " ).item( T2 ).str( " (" ).item( T2.id ).str( ") <a href='?src=" ).Ref( this ).str( ";link=1'>[Link]</a> <a href='?src=" ).Ref( this ).str( ";flush=1'>[Flush]" ).ToString();
					} else {
						dat += new Txt( "<br><br>MULTITOOL BUFFER: <a href='?src=" ).Ref( this ).str( ";buffer=1'>[Add Machine]</a>" ).ToString();
					}
				}
			}
			dat += "</font>";
			this.temp = "";
			Interface13.Browse( a, dat, "window=tcommachine;size=520x500;can_resize=0" );
			GlobalFuncs.onclose( a, "dormitory" );
			return null;
		}

		// Function from file: machine_interactions.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.attack_hand( user );
			return null;
		}

		// Function from file: machine_interactions.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic icon_closed = null;
			string icon_open = null;

			icon_closed = Lang13.Initial( this, "icon_state" );
			icon_open = "" + Lang13.Initial( this, "icon_state" ) + "_o";

			if ( !this.on ) {
				icon_closed = "" + Lang13.Initial( this, "icon_state" ) + "_off";
				icon_open = "" + Lang13.Initial( this, "icon_state" ) + "_o_off";
			}

			if ( this.default_deconstruction_screwdriver( user, icon_open, icon_closed, A ) ) {
				this.updateUsrDialog();
				return null;
			}

			if ( this.exchange_parts( user, A ) ) {
				return null;
			}

			if ( A is Obj_Item_Device_Multitool ) {
				this.attack_hand( user );
			}
			this.default_deconstruction_crowbar( A );
			return null;
		}

		// Function from file: swarmer.dm
		public override void swarmer_act( Mob_Living_SimpleAnimal_Hostile_Swarmer S = null ) {
			S.WriteMsg( "<span class='warning'>This communications relay should be preserved, it will be a useful resource to our masters in the future. Aborting.</span>" );
			return;
		}

	}

}