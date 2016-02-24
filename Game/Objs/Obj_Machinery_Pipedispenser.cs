// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Pipedispenser : Obj_Machinery {

		public bool wait = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon_state = "pipe_d";
		}

		public Obj_Machinery_Pipedispenser ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: pipe_dispenser.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			this.add_fingerprint( user );

			if ( A is Obj_Item_Pipe || A is Obj_Item_PipeMeter ) {
				Task13.User.WriteMsg( "<span class='notice'>You put " + A + " back into " + this + ".</span>" );

				if ( !Lang13.Bool( user.drop_item() ) ) {
					return null;
				}
				GlobalFuncs.qdel( A );
				return null;
			} else if ( A is Obj_Item_Weapon_Wrench ) {
				
				if ( !Lang13.Bool( this.anchored ) && !this.isinspace() ) {
					GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 50, 1 );
					user.WriteMsg( new Txt( "<span class='notice'>You begin to fasten " ).the( this ).item().str( " to the floor...</span>" ).ToString() );

					if ( GlobalFuncs.do_after( user, 40 / A.toolspeed, null, this ) ) {
						this.add_fingerprint( user );
						((Ent_Static)user).visible_message( new Txt().item( user ).str( " fastens " ).the( this ).item().str( "." ).ToString(), new Txt( "<span class='notice'>You fasten " ).the( this ).item().str( ". Now it can dispense pipes.</span>" ).ToString(), "<span class='italics'>You hear ratchet.</span>" );
						this.anchored = 1;
						this.stat &= 8;

						if ( Task13.User.machine == this ) {
							Interface13.Browse( Task13.User, null, "window=pipedispenser" );
						}
					}
				} else if ( Lang13.Bool( this.anchored ) ) {
					GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 50, 1 );
					user.WriteMsg( new Txt( "<span class='notice'>You begin to unfasten " ).the( this ).item().str( " from the floor...</span>" ).ToString() );

					if ( GlobalFuncs.do_after( user, 20 / A.toolspeed, null, this ) ) {
						this.add_fingerprint( user );
						((Ent_Static)user).visible_message( new Txt().item( user ).str( " unfastens " ).the( this ).item().str( "." ).ToString(), new Txt( "<span class='notice'>You unfasten " ).the( this ).item().str( ". Now it can be pulled somewhere else.</span>" ).ToString(), "<span class='italics'>You hear ratchet.</span>" );
						this.anchored = 0;
						this.stat |= 65527;
						this.power_change();
					}
				}
			} else {
				return base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: pipe_dispenser.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			Type p_type = null;
			double? p_dir = null;
			Obj_Item_Pipe P = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return 1;
			}

			if ( !Lang13.Bool( this.anchored ) || !Task13.User.canmove || Task13.User.stat != 0 || Task13.User.restrained() || !( Map13.GetDistance( this.loc, Task13.User ) <= 1 ) ) {
				Interface13.Browse( Task13.User, null, "window=pipedispenser" );
				return 1;
			}
			Task13.User.set_machine( this );
			this.add_fingerprint( Task13.User );

			if ( Lang13.Bool( href_list["make"] ) ) {
				
				if ( !this.wait ) {
					p_type = Lang13.FindClass( href_list["make"] );
					p_dir = String13.ParseNumber( href_list["dir"] );
					P = new Obj_Item_Pipe( this.loc, p_type, p_dir );
					P.add_fingerprint( Task13.User );
					this.wait = true;
					Task13.Schedule( 10, (Task13.Closure)(() => {
						this.wait = false;
						return;
					}));
				}
			}

			if ( Lang13.Bool( href_list["makemeter"] ) ) {
				
				if ( !this.wait ) {
					new Obj_Item_PipeMeter( this.loc );
					this.wait = true;
					Task13.Schedule( 15, (Task13.Closure)(() => {
						this.wait = false;
						return;
					}));
				}
			}
			return null;
		}

		// Function from file: pipe_dispenser.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			string dat = null;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), b, c ) ) ) {
				return 1;
			}
			dat = new Txt( "\n<b>Regular pipes:</b><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Pipe_Simple) ).str( ";dir=1'>Pipe</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Pipe_Simple) ).str( ";dir=5'>Bent Pipe</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Pipe_Manifold) ).str( ";dir=1'>Manifold</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Pipe_Manifold4w) ).str( ";dir=1'>4-Way Manifold</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Components_Binary_Valve) ).str( ";dir=1'>Manual Valve</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Components_Binary_Valve_Digital) ).str( ";dir=1'>Digital Valve</A><BR>\n<b>Devices:</b><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Components_Unary_PortablesConnector) ).str( ";dir=1'>Connector</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Components_Unary_VentPump) ).str( ";dir=1'>Vent</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Components_Binary_Pump) ).str( ";dir=1'>Gas Pump</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Components_Binary_PassiveGate) ).str( ";dir=1'>Passive Gate</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Components_Binary_VolumePump) ).str( ";dir=1'>Volume Pump</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Components_Unary_VentScrubber) ).str( ";dir=1'>Scrubber</A><BR>\n<A href='?src=" ).Ref( this ).str( ";makemeter=1'>Meter</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Components_Trinary_Filter) ).str( ";dir=1'>Gas Filter</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Components_Trinary_Mixer) ).str( ";dir=1'>Gas Mixer</A><BR>\n<b>Heat exchange:</b><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Pipe_HeatExchanging_Simple) ).str( ";dir=1'>Pipe</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Pipe_HeatExchanging_Simple) ).str( ";dir=5'>Bent Pipe</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold) ).str( ";dir=1'>Manifold</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold4w) ).str( ";dir=1'>4-Way Manifold</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Pipe_HeatExchanging_Junction) ).str( ";dir=1'>Junction</A><BR>\n<A href='?src=" ).Ref( this ).str( ";make=" ).item( typeof(Obj_Machinery_Atmospherics_Components_Unary_HeatExchanger) ).str( ";dir=1'>Heat Exchanger</A><BR>\n" ).ToString();
			Interface13.Browse( a, "<HEAD><TITLE>" + this + "</TITLE></HEAD><TT>" + dat + "</TT>", "window=pipedispenser" );
			GlobalFuncs.onclose( a, "pipedispenser" );
			return null;
		}

		// Function from file: pipe_dispenser.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

	}

}