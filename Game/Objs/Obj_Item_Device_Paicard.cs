// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Paicard : Obj_Item_Device {

		public bool looking_for_personality = false;
		public Mob_Living_Silicon_Pai pai = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "electronic";
			this.w_class = 2;
			this.slot_flags = 512;
			this.origin_tech = "programming=2";
			this.icon = "icons/obj/pda.dmi";
			this.icon_state = "pai";
		}

		// Function from file: paicard.dm
		public Obj_Item_Device_Paicard ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.overlays.Add( "pai-off" );
			return;
		}

		// Function from file: paicard.dm
		public override dynamic emp_act( int severity = 0 ) {
			dynamic M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this )) {
				M = _a;
				
				M.emp_act( severity );
			}
			base.emp_act( severity );
			return null;
		}

		// Function from file: paicard.dm
		public void alertUpdate(  ) {
			dynamic T = null;
			dynamic M = null;

			T = GlobalFuncs.get_turf( this.loc );

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, T ) )) {
				M = _a;
				
				M.show_message( "<span class='notice'>" + this + " flashes a message across its screen, \"Additional personalities available for download.\"</span>", 1, "<span class='notice'>" + this + " bleeps electronically.</span>", 2 );
				GlobalFuncs.playsound( this.loc, "sound/machines/paistartup.ogg", 50, 1 );
			}
			return;
		}

		// Function from file: paicard.dm
		public void setEmotion( int emotion = 0 ) {
			string face = null;

			
			if ( this.pai != null ) {
				face = "pai-happy";
				this.overlays.len = 0;
				this.pai.overlays.len = 0;

				switch ((int)( emotion )) {
					case 1:
						face = "pai-happy";
						break;
					case 2:
						face = "pai-cat";
						break;
					case 3:
						face = "pai-extremely-happy";
						break;
					case 4:
						face = "pai-face";
						break;
					case 5:
						face = "pai-laugh";
						break;
					case 6:
						face = "pai-off";
						break;
					case 7:
						face = "pai-sad";
						break;
					case 8:
						face = "pai-angry";
						break;
					case 9:
						face = "pai-what";
						break;
					case 10:
						face = "pai-longface";
						break;
					case 11:
						face = "pai-sick";
						break;
					case 12:
						face = "pai-high";
						break;
					case 13:
						face = "pai-love";
						break;
					case 14:
						face = "pai-electric";
						break;
					case 15:
						face = "pai-pissed";
						break;
					case 16:
						face = "pai-nose";
						break;
					case 17:
						face = "pai-kawaii";
						break;
					case 18:
						face = "pai-cry";
						break;
				}
				this.overlays.Add( "" + face );
				this.pai.overlays.Add( "" + face );
			}
			return;
		}

		// Function from file: paicard.dm
		public void removePersonality(  ) {
			this.pai = null;
			this.overlays.len = 0;
			this.overlays.Add( "pai-off" );
			return;
		}

		// Function from file: paicard.dm
		public void setPersonality( Mob_Living_Silicon_Pai personality = null ) {
			this.pai = personality;
			this.overlays.Add( "pai-happy" );
			return;
		}

		// Function from file: paicard.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			Mob M = null;
			Dna dna = null;
			dynamic confirm = null;
			dynamic M2 = null;
			double? t1 = null;
			string newlaws = null;

			
			if ( !( Task13.User != null ) || Lang13.Bool( Task13.User.stat ) ) {
				return null;
			}

			if ( Lang13.Bool( href_list["setdna"] ) ) {
				
				if ( Lang13.Bool( this.pai.master_dna ) ) {
					return null;
				}
				M = Task13.User;

				if ( !( M is Mob_Living_Carbon ) ) {
					GlobalFuncs.to_chat( Task13.User, "<font color=blue>You don't have any DNA, or your DNA is incompatible with this device.</font>" );
				} else {
					dna = Task13.User.dna;
					this.pai.master = M.real_name;
					this.pai.master_dna = dna.unique_enzymes;
					GlobalFuncs.to_chat( this.pai, "<font color = red><h3>You have been bound to a new master.</h3></font>" );
				}
			}

			if ( Lang13.Bool( href_list["request"] ) ) {
				this.looking_for_personality = true;
				GlobalVars.paiController.findPAI( this, Task13.User );
			}

			if ( Lang13.Bool( href_list["wipe"] ) ) {
				confirm = Interface13.Input( "Are you CERTAIN you wish to delete the current personality? This action cannot be undone.", "Personality Wipe", null, null, new ByTable(new object [] { "Yes", "No" }), InputType.Any );

				if ( confirm == "Yes" ) {
					
					foreach (dynamic _a in Lang13.Enumerate( this )) {
						M2 = _a;
						
						GlobalFuncs.to_chat( M2, "<font color = #ff0000><h2>You feel yourself slipping away from reality.</h2></font>" );
						GlobalFuncs.to_chat( M2, "<font color = #ff4d4d><h3>Byte by byte you lose your sense of self.</h3></font>" );
						GlobalFuncs.to_chat( M2, "<font color = #ff8787><h4>Your mental faculties leave you.</h4></font>" );
						GlobalFuncs.to_chat( M2, "<font color = #ffc4c4><h5>oblivion... </h5></font>" );
						((Mob)M2).death( false );
					}
					this.removePersonality();
				}
			}

			if ( Lang13.Bool( href_list["wires"] ) ) {
				t1 = String13.ParseNumber( href_list["wires"] );

				if ( this.pai.v_radio != null ) {
					this.pai.v_radio.wires.CutWireIndex( t1 );
				}
			}

			if ( Lang13.Bool( href_list["setlaws"] ) ) {
				newlaws = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( "Enter any additional directives you would like your pAI personality to follow. Note that these directives will not override the personality's allegiance to its imprinted master. Conflicting directives will be ignored.", "pAI Directive Configuration", this.pai.pai_laws, null, null, InputType.StrMultiline ) ), 1, 1024 );

				if ( Lang13.Bool( newlaws ) ) {
					this.pai.pai_laws = newlaws;
					GlobalFuncs.to_chat( this.pai, "Your supplemental directives have been updated. Your new directives are:" );
					GlobalFuncs.to_chat( this.pai, "Prime Directive : <br>" + this.pai.pai_law0 );
					GlobalFuncs.to_chat( this.pai, "Supplemental Directives: <br>" + this.pai.pai_laws );
				}
			}
			this.attack_self( Task13.User );
			return null;
		}

		// Function from file: paicard.dm
		public override dynamic attack_ghost( Mob_Dead_Observer user = null ) {
			
			if ( this.looking_for_personality && GlobalVars.paiController.check_recruit( user ) ) {
				GlobalVars.paiController.recruitWindow( user );
			} else {
				this.visible_message( new Txt( "<span class='notice'>" ).The( this ).item().str( " pings softly.</span>" ).ToString() );
			}
			return null;
		}

		// Function from file: paicard.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			string dat = null;

			
			if ( !GlobalFuncs.in_range( this, user ) ) {
				return null;
			}
			((Mob)user).set_machine( this );
			dat = "<TT><B>Personal AI Device</B><BR>";

			if ( this.pai != null && ( !Lang13.Bool( this.pai.master_dna ) || !Lang13.Bool( this.pai.master ) ) ) {
				dat += new Txt( "<a href='byond://?src=" ).Ref( this ).str( ";setdna=1'>Imprint Master DNA</a><br>" ).ToString();
			}

			if ( this.pai != null ) {
				dat += new Txt( "Installed Personality: " ).item( this.pai.name ).str( "<br>\n			Prime directive: <br>" ).item( this.pai.pai_law0 ).str( "<br>\n			Additional directives: <br>" ).item( this.pai.pai_laws ).str( "<br>\n			<a href='byond://?src=" ).Ref( this ).str( ";setlaws=1'>Configure Directives</a><br>\n			<br>\n			<h3>Device Settings</h3><br>" ).ToString();

				if ( this.pai.v_radio != null ) {
					dat += "<b>Radio Uplink</b><br>";
					dat += new Txt( "Transmit: <A href='byond://?src=" ).Ref( this ).str( ";wires=" ).item( GlobalVars.WIRE_TRANSMIT ).str( "'>" ).item( ( this.pai.v_radio.wires.IsIndexCut( GlobalVars.WIRE_TRANSMIT ) != 0 ? "Disabled" : "Enabled" ) ).str( "</A><br>" ).ToString();
					dat += new Txt( "Receive: <A href='byond://?src=" ).Ref( this ).str( ";wires=" ).item( GlobalVars.WIRE_RECEIVE ).str( "'>" ).item( ( this.pai.v_radio.wires.IsIndexCut( GlobalVars.WIRE_RECEIVE ) != 0 ? "Disabled" : "Enabled" ) ).str( "</A><br>" ).ToString();
				} else {
					dat += "<b>Radio Uplink</b><br>\n				<font color=red><i>Radio firmware not loaded. Please install a pAI personality to load firmware.</i></font><br>";
				}
				dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";wipe=1'>[Wipe current pAI personality]</a><br>" ).ToString();
			} else if ( this.looking_for_personality ) {
				dat += new Txt( "Searching for a personality...\n				<A href='byond://?src=" ).Ref( this ).str( ";request=1'>[View available personalities]</a><br>" ).ToString();
			} else {
				dat += new Txt( "No personality is installed.<br>\n				<A href='byond://?src=" ).Ref( this ).str( ";request=1'>[Request personal AI personality]</a><br>\n				Each time this button is pressed, a request will be sent out to any available personalities. Check back often and alot time for personalities to respond. This process could take anywhere from 15 seconds to several minutes, depending on the available personalities' timeliness." ).ToString();
			}
			Interface13.Browse( user, dat, "window=paicard" );
			GlobalFuncs.onclose( user, "paicard" );
			return null;
		}

		// Function from file: paicard.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( !( this.pai == null ) ) {
				this.pai.death( false );
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}