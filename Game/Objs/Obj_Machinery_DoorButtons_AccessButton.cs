// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_DoorButtons_AccessButton : Obj_Machinery_DoorButtons {

		public string idDoor = null;
		public Obj_Machinery_Door_Airlock door = null;
		public Obj_Machinery_DoorButtons_AirlockController controller = null;
		public bool busy = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/airlock_machines.dmi";
			this.icon_state = "access_button_standby";
		}

		public Obj_Machinery_DoorButtons_AccessButton ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: access_controller.dm
		public override void removeMe( Obj_Machinery_Door_Airlock O = null ) {
			
			if ( O == this.door ) {
				this.door = null;
			}
			return;
		}

		// Function from file: access_controller.dm
		public override void power_change(  ) {
			base.power_change();
			this.update_icon();
			return;
		}

		// Function from file: access_controller.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( ( this.stat & 2 ) != 0 ) {
				this.icon_state = "access_button_off";
			} else if ( this.busy ) {
				this.icon_state = "access_button_cycle";
			} else {
				this.icon_state = "access_button_standby";
			}
			return false;
		}

		// Function from file: access_controller.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( Lang13.Bool( base.attack_hand( (object)(a), b, c ) ) ) {
				return null;
			}

			if ( this.busy ) {
				return null;
			}

			if ( !this.allowed( a ) ) {
				a.WriteMsg( "<span class='warning'>Access denied.</span>" );
				return null;
			}

			if ( this.controller != null && !( this.controller.busy != 0 ) && this.door != null ) {
				
				if ( ( this.controller.stat & 2 ) != 0 ) {
					return null;
				}
				this.busy = true;
				this.update_icon();

				if ( this.door.density ) {
					
					if ( !( this.controller.exteriorAirlock != null ) || !( this.controller.interiorAirlock != null ) ) {
						this.controller.onlyOpen( this.door );
					} else if ( this.controller.exteriorAirlock.density && this.controller.interiorAirlock.density ) {
						this.controller.onlyOpen( this.door );
					} else {
						this.controller.cycleClose( this.door );
					}
				} else {
					this.controller.onlyClose( this.door );
				}
				Task13.Sleep( 20 );
				this.busy = false;
				this.update_icon();
			}
			return null;
		}

		// Function from file: access_controller.dm
		public override void findObjsByTag(  ) {
			Obj_Machinery_DoorButtons_AirlockController A = null;
			Obj_Machinery_Door_Airlock I = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_DoorButtons_AirlockController) )) {
				A = _a;
				

				if ( A.idSelf == this.idSelf ) {
					this.controller = A;
					break;
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.machines, typeof(Obj_Machinery_Door_Airlock) )) {
				I = _b;
				

				if ( I.id_tag == this.idDoor ) {
					this.door = I;
					break;
				}
			}
			return;
		}

	}

}