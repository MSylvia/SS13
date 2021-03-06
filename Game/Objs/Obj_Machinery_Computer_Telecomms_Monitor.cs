// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Telecomms_Monitor : Obj_Machinery_Computer_Telecomms {

		public bool screen = false;
		public ByTable machinelist = new ByTable();
		public Obj_Machinery_Telecomms SelectedMachine = null;
		public string network = "NULL";
		public string temp = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_screen = "comm_monitor";
			this.circuit = "/obj/item/weapon/circuitboard/comm_monitor";
		}

		public Obj_Machinery_Computer_Telecomms_Monitor ( dynamic location = null, dynamic C = null ) : base( (object)(location), (object)(C) ) {
			
		}

		// Function from file: tgstation.dme
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			this.updateUsrDialog();
			return null;
		}

		// Function from file: telemonitor.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			Obj_Machinery_Telecomms T = null;
			Obj_Machinery_Telecomms T2 = null;
			string newnet = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}
			this.add_fingerprint( Task13.User );
			Task13.User.set_machine( this );

			if ( Lang13.Bool( href_list["viewmachine"] ) ) {
				this.screen = true;

				foreach (dynamic _a in Lang13.Enumerate( this.machinelist, typeof(Obj_Machinery_Telecomms) )) {
					T = _a;
					

					if ( T.id == href_list["viewmachine"] ) {
						this.SelectedMachine = T;
						break;
					}
				}
			}

			if ( Lang13.Bool( href_list["operation"] ) ) {
				
				dynamic _c = href_list["operation"]; // Was a switch-case, sorry for the mess.
				if ( _c=="release" ) {
					this.machinelist = new ByTable();
					this.screen = false;
				} else if ( _c=="mainmenu" ) {
					this.screen = false;
				} else if ( _c=="probe" ) {
					
					if ( this.machinelist.len > 0 ) {
						this.temp = "<font color = #D70B00>- FAILED: CANNOT PROBE WHEN BUFFER FULL -</font color>";
					} else {
						
						foreach (dynamic _b in Lang13.Enumerate( GlobalFuncs.ultra_range( 25, this ), typeof(Obj_Machinery_Telecomms) )) {
							T2 = _b;
							

							if ( T2.network == this.network ) {
								this.machinelist.Add( T2 );
							}
						}

						if ( !( this.machinelist.len != 0 ) ) {
							this.temp = "<font color = #D70B00>- FAILED: UNABLE TO LOCATE NETWORK ENTITIES IN [" + this.network + "] -</font color>";
						} else {
							this.temp = "<font color = #336699>- " + this.machinelist.len + " ENTITIES LOCATED & BUFFERED -</font color>";
						}
						this.screen = false;
					}
				}
			}

			if ( Lang13.Bool( href_list["network"] ) ) {
				newnet = GlobalFuncs.stripped_input( Task13.User, "Which network do you want to view?", "Comm Monitor", this.network );

				if ( Lang13.Bool( newnet ) && ( Map13.FetchInRange( this, 1 ).Contains( Task13.User ) || Task13.User is Mob_Living_Silicon ) ) {
					
					if ( Lang13.Length( newnet ) > 15 ) {
						this.temp = "<font color = #D70B00>- FAILED: NETWORK TAG STRING TOO LENGHTLY -</font color>";
					} else {
						this.network = newnet;
						this.screen = false;
						this.machinelist = new ByTable();
						this.temp = "<font color = #336699>- NEW NETWORK TAG SET IN ADDRESS [" + this.network + "] -</font color>";
					}
				}
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: telemonitor.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			string dat = null;
			Obj_Machinery_Telecomms T = null;
			Obj_Machinery_Telecomms T2 = null;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), b, c ) ) ) {
				return null;
			}
			((Mob)a).set_machine( this );
			dat = "<TITLE>Telecommunications Monitor</TITLE><center><b>Telecommunications Monitor</b></center>";

			switch ((bool)( this.screen )) {
				case false:
					dat += "<br>" + this.temp + "<br><br>";
					dat += new Txt( "<br>Current Network: <a href='?src=" ).Ref( this ).str( ";network=1'>" ).item( this.network ).str( "</a><br>" ).ToString();

					if ( this.machinelist.len != 0 ) {
						dat += "<br>Detected Network Entities:<ul>";

						foreach (dynamic _a in Lang13.Enumerate( this.machinelist, typeof(Obj_Machinery_Telecomms) )) {
							T = _a;
							
							dat += new Txt( "<li><a href='?src=" ).Ref( this ).str( ";viewmachine=" ).item( T.id ).str( "'>" ).Ref( T ).str( " " ).item( T.name ).str( "</a> (" ).item( T.id ).str( ")</li>" ).ToString();
						}
						dat += "</ul>";
						dat += new Txt( "<br><a href='?src=" ).Ref( this ).str( ";operation=release'>[Flush Buffer]</a>" ).ToString();
					} else {
						dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";operation=probe'>[Probe Network]</a>" ).ToString();
					}
					break;
				case true:
					dat += "<br>" + this.temp + "<br>";
					dat += new Txt( "<center><a href='?src=" ).Ref( this ).str( ";operation=mainmenu'>[Main Menu]</a></center>" ).ToString();
					dat += "<br>Current Network: " + this.network + "<br>";
					dat += "Selected Network Entity: " + this.SelectedMachine.name + " (" + this.SelectedMachine.id + ")<br>";
					dat += "Linked Entities: <ol>";

					foreach (dynamic _b in Lang13.Enumerate( this.SelectedMachine.links, typeof(Obj_Machinery_Telecomms) )) {
						T2 = _b;
						

						if ( !T2.v_hide ) {
							dat += new Txt( "<li><a href='?src=" ).Ref( this ).str( ";viewmachine=" ).item( T2.id ).str( "'>" ).Ref( T2.id ).str( " " ).item( T2.name ).str( "</a> (" ).item( T2.id ).str( ")</li>" ).ToString();
						}
					}
					dat += "</ol>";
					break;
			}
			Interface13.Browse( a, dat, "window=comm_monitor;size=575x400" );
			GlobalFuncs.onclose( a, "server_control" );
			this.temp = "";
			return null;
		}

	}

}