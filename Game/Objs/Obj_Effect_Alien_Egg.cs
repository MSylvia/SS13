// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Alien_Egg : Obj_Effect_Alien {

		public double health = 100;
		public dynamic status = 2;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.flags = 1;
			this.icon_state = "egg_growing";
		}

		// Function from file: aliens.dm
		public Obj_Effect_Alien_Egg ( dynamic loc = null ) : base( (object)(loc) ) {
			
			if ( GlobalVars.aliens_allowed ) {
				Task13.Schedule( Rand13.Int( GlobalVars.MIN_GROWTH_TIME, GlobalVars.MAX_GROWTH_TIME ), (Task13.Closure)(() => {
					this.Grow();
					return;
				}));
			} else {
				GlobalFuncs.qdel( this );
			}
			return;
		}

		// Function from file: aliens.dm
		public override bool HasProximity( dynamic AM = null ) {
			dynamic C = null;

			
			if ( this.status == GlobalVars.GROWN ) {
				
				if ( !GlobalFuncs.CanHug( AM ) ) {
					return false;
				}
				C = AM;

				if ( Lang13.Bool( C.stat ) == false && ( C.status_flags & 32768 ) != 0 ) {
					return false;
				}
				this.Burst( false );
			}
			return false;
		}

		// Function from file: aliens.dm
		public override bool fire_act( GasMixture air = null, double? exposed_temperature = null, int exposed_volume = 0 ) {
			
			if ( ( exposed_temperature ??0) > 500 ) {
				this.health -= 5;
				this.healthcheck();
			}
			return false;
		}

		// Function from file: aliens.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic damage = null;
			dynamic WT = null;

			
			if ( this.health <= 0 ) {
				return null;
			}
			((Mob)b).delayNextAttack( 10 );

			if ( Lang13.Bool( a.attack_verb ) && a.attack_verb.len != 0 ) {
				this.visible_message( new Txt( "<span class='warning'><B>" ).The( this ).item().str( " has been " ).item( Rand13.PickFromTable( a.attack_verb ) ).str( " with " ).the( a ).item().item( ( Lang13.Bool( b ) ? " by " + b + "." : "." ) ).str( "</span>" ).ToString() );
			} else {
				this.visible_message( new Txt( "<span class='warning'><B>" ).The( this ).item().str( " has been attacked with " ).the( a ).item().item( ( Lang13.Bool( b ) ? " by " + b + "." : "." ) ).str( "</span>" ).ToString() );
			}
			damage = a.force / 4;

			if ( a is Obj_Item_Weapon_Weldingtool ) {
				WT = a;

				if ( Lang13.Bool( WT.remove_fuel( 0, b ) ) ) {
					damage = 15;
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/welder.ogg", 100, 1 );
				}
			}
			this.health -= Convert.ToDouble( damage );
			this.healthcheck();
			return null;
		}

		// Function from file: aliens.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			this.health -= Convert.ToDouble( Proj.damage );
			base.bullet_act( (object)(Proj), (object)(def_zone) );
			this.healthcheck();
			return null;
		}

		// Function from file: aliens.dm
		public void healthcheck(  ) {
			
			if ( this.health <= 0 ) {
				this.Burst();
			}
			return;
		}

		// Function from file: aliens.dm
		public void Burst( bool? kill = null ) {
			kill = kill ?? true;

			dynamic child = null;
			Game_Data O = null;
			dynamic M = null;

			
			if ( this.status == GlobalVars.GROWN || this.status == GlobalVars.GROWING ) {
				child = this.GetFacehugger();
				this.icon_state = "egg_hatched";
				Icon13.Flick( "egg_opening", this );
				this.status = GlobalVars.BURSTING;
				Task13.Schedule( 15, (Task13.Closure)(() => {
					this.status = GlobalVars.BURST;

					if ( !Lang13.Bool( child ) ) {
						this.visible_message( "<span class='warning'>The egg bursts apart revealing nothing</span>" );
						this.status = "GROWN";
						new Obj_Effect_Decal_Cleanable_Blood_Xeno( this );
						O = GlobalFuncs.getFromPool( typeof(Obj_Effect_Decal_Cleanable_Blood_Xeno), this );
						((dynamic)O).New( this );
					}
					child.loc = this.loc;

					if ( kill == true && child is Obj_Item_Clothing_Mask_Facehugger ) {
						child.Die();
					} else {
						
						foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRange( this, 1 ) )) {
							M = _a;
							

							if ( GlobalFuncs.CanHug( M ) ) {
								child.Attach( M );
								break;
							}
						}
					}
					return;
				}));
			}
			return;
		}

		// Function from file: aliens.dm
		public void Grow(  ) {
			this.icon_state = "egg";
			this.status = GlobalVars.GROWN;
			new Obj_Item_Clothing_Mask_Facehugger( this );
			return;
		}

		// Function from file: aliens.dm
		public dynamic GetFacehugger(  ) {
			return Lang13.FindIn( typeof(Obj_Item_Clothing_Mask_Facehugger), this.contents );
		}

		// Function from file: aliens.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			GlobalFuncs.to_chat( a, "It feels slimy." );
			return null;
		}

		// Function from file: aliens.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			
			if ( a is Mob_Living_Carbon_Alien ) {
				
				dynamic _a = this.status; // Was a switch-case, sorry for the mess.
				if ( _a==0 ) {
					GlobalFuncs.to_chat( a, "<span class='warning'>You clear the hatched egg.</span>" );
					GlobalFuncs.qdel( this );
					return null;
				} else if ( _a==2 ) {
					GlobalFuncs.to_chat( a, "<span class='warning'>The child is not developed yet.</span>" );
					return null;
				} else if ( _a==3 ) {
					GlobalFuncs.to_chat( a, "<span class='warning'>You retrieve the child.</span>" );
					this.Burst( false );
					return null;
				}
			} else {
				return this.attack_hand( a );
			}
			return null;
		}

	}

}