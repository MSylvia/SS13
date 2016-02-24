// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_AssemblyHolder : Obj_Item_Device {

		public dynamic a_left = null;
		public dynamic a_right = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "assembly";
			this.flags = 64;
			this.throwforce = 5;
			this.w_class = 2;
			this.icon = "icons/obj/assemblies/new_assemblies.dmi";
			this.icon_state = "holder";
		}

		public Obj_Item_Device_AssemblyHolder ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: holder.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.add_fingerprint( user );

			if ( !Lang13.Bool( this.a_left ) || !Lang13.Bool( this.a_right ) ) {
				user.WriteMsg( "<span class='danger'>Assembly part missing!</span>" );
				return null;
			}

			if ( Lang13.Bool( ((dynamic)this.a_right.type).IsInstanceOfType( this.a_left ) ) ) {
				
				switch ((string)( Interface13.Alert( "Which side would you like to use?", null, "Left", "Right" ) )) {
					case "Left":
						((Obj_Item)this.a_left).attack_self( user );
						break;
					case "Right":
						((Obj_Item)this.a_right).attack_self( user );
						break;
				}
				return null;
			} else {
				((Obj_Item)this.a_left).attack_self( user );
				((Obj_Item)this.a_right).attack_self( user );
			}
			return null;
		}

		// Function from file: holder.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic T = null;

			
			if ( A is Obj_Item_Weapon_Screwdriver ) {
				T = GlobalFuncs.get_turf( this );

				if ( !Lang13.Bool( T ) ) {
					return 0;
				}

				if ( Lang13.Bool( this.a_left ) ) {
					this.a_left.holder = null;
					this.a_left.loc = T;
				}

				if ( Lang13.Bool( this.a_right ) ) {
					this.a_right.holder = null;
					this.a_right.loc = T;
				}
				GlobalFuncs.qdel( this );
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: holder.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( Lang13.Bool( this.a_left ) && Lang13.Bool( this.a_right ) ) {
				((Obj_Item_Device_Assembly)this.a_left).holder_movement();
				((Obj_Item_Device_Assembly)this.a_right).holder_movement();
			}
			base.attack_hand( (object)(a), b, c );
			return null;
		}

		// Function from file: holder.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			base.Move( (object)(NewLoc), Dir, step_x, step_y );

			if ( Lang13.Bool( this.a_left ) && Lang13.Bool( this.a_right ) ) {
				((Obj_Item_Device_Assembly)this.a_left).holder_movement();
				((Obj_Item_Device_Assembly)this.a_right).holder_movement();
			}
			return false;
		}

		// Function from file: holder.dm
		public override bool on_found( dynamic finder = null ) {
			
			if ( Lang13.Bool( this.a_left ) ) {
				((Obj_Item)this.a_left).on_found( finder );
			}

			if ( Lang13.Bool( this.a_right ) ) {
				((Obj_Item)this.a_right).on_found( finder );
			}
			return false;
		}

		// Function from file: holder.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			
			if ( Lang13.Bool( this.a_left ) ) {
				((Base_Dynamic)this.a_left).Crossed( O );
			}

			if ( Lang13.Bool( this.a_right ) ) {
				((Base_Dynamic)this.a_right).Crossed( O );
			}
			return null;
		}

		// Function from file: holder.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			dynamic O = null;
			ByTable images = null;
			dynamic O2 = null;
			Matrix matrix = null;
			Image I = null;

			this.overlays.Cut();

			if ( Lang13.Bool( this.a_left ) ) {
				this.overlays.Add( "" + this.a_left.icon_state + "_left" );

				foreach (dynamic _a in Lang13.Enumerate( this.a_left.attached_overlays )) {
					O = _a;
					
					this.overlays.Add( "" + O + "_l" );
				}
			}

			if ( Lang13.Bool( this.a_right ) ) {
				images = new ByTable();
				images.Add( new Image( this.icon, null, "" + this.a_right.icon_state + "_left" ) );

				foreach (dynamic _b in Lang13.Enumerate( this.a_right.attached_overlays )) {
					O2 = _b;
					
					images.Add( new Image( this.icon, null, "" + O2 + "_l" ) );
				}
				matrix = Num13.Matrix( -1, 0, 0, 0, 1, 0 );

				foreach (dynamic _c in Lang13.Enumerate( images, typeof(Image) )) {
					I = _c;
					
					I.transform = matrix;
					this.overlays.Add( I );
				}
			}

			if ( Lang13.Bool( this.master ) ) {
				this.master.update_icon();
			}
			return false;
		}

		// Function from file: holder.dm
		public bool process_activation( Obj_Item_Device_Assembly D = null, bool? normal = null, bool? special = null ) {
			normal = normal ?? true;
			special = special ?? true;

			
			if ( !( D != null ) ) {
				return false;
			}

			if ( normal == true && Lang13.Bool( this.a_right ) && Lang13.Bool( this.a_left ) ) {
				
				if ( this.a_right != D ) {
					((Obj_Item_Device_Assembly)this.a_right).pulsed( false );
				}

				if ( this.a_left != D ) {
					((Obj_Item_Device_Assembly)this.a_left).pulsed( false );
				}
			}

			if ( Lang13.Bool( this.master ) ) {
				this.master.receive_signal();
			}
			return true;
		}

		// Function from file: holder.dm
		public void attach( dynamic A = null, dynamic user = null ) {
			
			if ( !((Obj_Item)A).remove_item_from_storage( this ) ) {
				
				if ( Lang13.Bool( user ) ) {
					((Mob)user).remove_from_mob( A );
				}
				A.loc = this;
			}
			A.holder = this;
			((Obj_Item_Device_Assembly)A).toggle_secure();

			if ( !Lang13.Bool( this.a_left ) ) {
				this.a_left = A;
			} else {
				this.a_right = A;
			}
			return;
		}

		// Function from file: holder.dm
		public void assemble( Obj_Item_Device_Assembly A = null, dynamic A2 = null, dynamic user = null ) {
			this.attach( A, user );
			this.attach( A2, user );
			this.name = "" + A.name + "-" + A2.name + " assembly";
			this.update_icon();
			GlobalFuncs.feedback_add_details( "assembly_made", "" + A.name + "-" + A2.name );
			return;
		}

		// Function from file: holder.dm
		public override bool IsAssemblyHolder(  ) {
			return true;
		}

	}

}