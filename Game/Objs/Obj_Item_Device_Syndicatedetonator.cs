// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Syndicatedetonator : Obj_Item_Device {

		public bool cooldown = false;
		public int detonated = 0;
		public int existant = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "electronic";
			this.w_class = 1;
			this.origin_tech = "syndicate=2";
			this.icon = "icons/obj/assemblies.dmi";
			this.icon_state = "bigred";
		}

		public Obj_Item_Device_Syndicatedetonator ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: syndicatebomb.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			Obj_Machinery_Syndicatebomb B = null;
			dynamic T = null;
			dynamic A = null;
			string log_str = null;

			
			if ( !this.cooldown ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Syndicatebomb) )) {
					B = _a;
					

					if ( B.active ) {
						B.timer = 0;
						this.detonated++;
					}
					this.existant++;
				}
				GlobalFuncs.playsound( user, "sound/machines/click.ogg", 20, 1 );
				user.WriteMsg( "<span class='notice'>" + this.existant + " found, " + this.detonated + " triggered.</span>" );

				if ( this.detonated != 0 ) {
					T = GlobalFuncs.get_turf( this );
					A = GlobalFuncs.get_area( T );
					this.detonated--;
					log_str = new Txt().item( GlobalFuncs.key_name_admin( user ) ).str( "<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( user ).str( "'>?</A> (<A HREF='?_src_=holder;adminplayerobservefollow=" ).Ref( user ).str( "'>FLW</A>) has remotely detonated " ).item( ( this.detonated != 0 ? "syndicate bombs" : "a syndicate bomb" ) ).str( " using a " ).item( this.name ).str( " at <A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" ).item( T.x ).str( ";Y=" ).item( T.y ).str( ";Z=" ).item( T.z ).str( "'>" ).item( A.name ).str( " (JMP)</a>." ).ToString();
					GlobalVars.bombers.Add( log_str );
					GlobalFuncs.message_admins( log_str );
					GlobalFuncs.log_game( "" + GlobalFuncs.key_name( user ) + " has remotely detonated " + ( this.detonated != 0 ? "syndicate bombs" : "a syndicate bomb" ) + " using a " + this.name + " at " + A.name + "(" + T.x + "," + T.y + "," + T.z + ")" );
				}
				this.detonated = 0;
				this.existant = 0;
				this.cooldown = true;
				Task13.Schedule( 30, (Task13.Closure)(() => {
					this.cooldown = false;
					return;
				}));
			}
			return null;
		}

	}

}