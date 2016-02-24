// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Artillerycontrol : Obj_Machinery {

		public int reload = 60;
		public int explosionsize = 3;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/machines/particle_accelerator.dmi";
			this.icon_state = "control_boxp1";
		}

		public Obj_Machinery_Artillerycontrol ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: bluespaceartillery.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			dynamic A = null;
			Base_Data thearea = null;
			ByTable L = null;
			dynamic T = null;
			dynamic loc = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}
			A = Interface13.Input( "Area to jump bombard", "Open Fire", A, null, GlobalVars.teleportlocs, InputType.Any );
			thearea = GlobalVars.teleportlocs[A];

			if ( Task13.User.stat != 0 || Task13.User.restrained() ) {
				return null;
			}

			if ( this.reload < 60 ) {
				return null;
			}

			if ( Task13.User.contents.Find( this ) != 0 || Map13.GetDistance( this, Task13.User ) <= 1 && this.loc is Tile || Task13.User is Mob_Living_Silicon ) {
				GlobalFuncs.priority_announce( "Bluespace artillery fire detected. Brace for impact." );
				GlobalFuncs.message_admins( "" + GlobalFuncs.key_name_admin( Task13.User ) + " has launched an artillery strike." );
				L = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_area_turfs( thearea.type ) )) {
					T = _a;
					
					L.Add( T );
				}
				loc = Rand13.PickFromTable( L );
				GlobalFuncs.explosion( loc, this.explosionsize, this.explosionsize * 2, this.explosionsize * 4 );
				this.reload = 0;
			}
			return null;
		}

		// Function from file: bluespaceartillery.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			string dat = null;

			((Mob)a).set_machine( this );
			dat = "<B>Bluespace Artillery Control:</B><BR>";
			dat += "Locked on<BR>";
			dat += "<B>Charge progress: " + this.reload + "/" + 60 + ":</B><BR>";
			dat += new Txt( "<A href='byond://?src=" ).Ref( this ).str( ";fire=1'>Open Fire</A><BR>" ).ToString();
			dat += "Deployment of weapon authorized by <br>Nanotrasen Naval Command<br><br>Remember, friendly fire is grounds for termination of your contract and life.<HR>";
			Interface13.Browse( a, dat, "window=scroll" );
			GlobalFuncs.onclose( a, "scroll" );
			return null;
		}

		// Function from file: bluespaceartillery.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( this.reload < 60 ) {
				this.reload++;
			}
			return null;
		}

	}

}