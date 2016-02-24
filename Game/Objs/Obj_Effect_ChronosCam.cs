// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ChronosCam : Obj_Effect {

		public Ent_Static holder = null;
		public int phase_time = 0;
		public int phase_time_length = 3;
		public Obj_Screen_ChronosTarget target_ui = null;
		public Obj_Item_Clothing_Suit_Space_Chronos chronosuit = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.invisibility = 101;
			this.anchored = 1;
		}

		public Obj_Effect_ChronosCam ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: chronosuit.dm
		public override dynamic Destroy(  ) {
			
			if ( this.holder != null ) {
				
				if ( ((dynamic)this.holder).remote_control == this ) {
					((dynamic)this.holder).remote_control = null;
				}

				if ( Lang13.Bool( ((dynamic)this.holder).client ) && ((dynamic)this.holder).client.eye == this ) {
					((Mob)this.holder).unset_machine();
				}
			}
			return base.Destroy();
		}

		// Function from file: chronosuit.dm
		public override void on_unset_machine( Mob user = null ) {
			user.reset_perspective( null );
			return;
		}

		// Function from file: chronosuit.dm
		public override dynamic check_eye( Mob user = null ) {
			
			if ( user != this.holder ) {
				user.unset_machine();
			}
			return null;
		}

		// Function from file: chronosuit.dm
		public override bool relaymove( Mob user = null, int? direction = null ) {
			Tile step = null;

			
			if ( this.holder != null ) {
				
				if ( user == this.holder ) {
					
					if ( this.loc == user ) {
						this.loc = GlobalFuncs.get_turf( user );
					}

					if ( user.client != null && user.client.eye != this ) {
						this.loc = GlobalFuncs.get_turf( user );
						user.reset_perspective( this );
						user.set_machine( this );
					}
					step = Map13.GetStep( this, direction ??0 );

					if ( step != null ) {
						
						if ( step.x <= 7 || step.x >= Game13.map_size_x - 7 - 1 || step.y <= 7 || step.y >= Game13.map_size_y - 7 - 1 ) {
							
							if ( !this.Move( step ) ) {
								this.loc = step;
							}
						} else {
							this.loc = step;
						}

						if ( this.x == this.holder.x && this.y == this.holder.y && this.z == this.holder.z ) {
							this.remove_target_ui();
							this.loc = user;
						} else if ( !( this.target_ui != null ) ) {
							this.create_target_ui();
						}
						this.phase_time = Game13.time + this.phase_time_length;
					}
				}
			} else {
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: chronosuit.dm
		public void remove_target_ui(  ) {
			
			if ( this.target_ui != null ) {
				GlobalFuncs.qdel( this.target_ui );
				this.target_ui = null;
			}
			return;
		}

		// Function from file: chronosuit.dm
		public void create_target_ui(  ) {
			
			if ( this.holder != null && Lang13.Bool( ((dynamic)this.holder).client ) && this.chronosuit != null ) {
				
				if ( this.target_ui != null ) {
					this.remove_target_ui();
				}
				this.target_ui = new Obj_Screen_ChronosTarget( null, this.holder );
				((dynamic)this.holder).client.screen += this.target_ui;
			}
			return;
		}

	}

}