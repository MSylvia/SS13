// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Mimic_Crate : Mob_Living_SimpleAnimal_Hostile_Mimic {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.a_intent = "hurt";
		}

		// Function from file: mimic.dm
		public Mob_Living_SimpleAnimal_Hostile_Mimic_Crate ( dynamic loc = null, dynamic new_disguise = null ) : base( (object)(loc) ) {
			
			if ( new_disguise is Type ) {
				this.copied_object = new_disguise;
			} else if ( new_disguise is Ent_Static ) {
				this.copied_object = new_disguise.type;
			} else {
				this.environment_disguise();
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.drop_meat( this );
			this.initialize();
			return;
		}

		// Function from file: mimic.dm
		public override int? bullet_act( dynamic Proj = null, dynamic def_zone = null ) {
			base.bullet_act( (object)(Proj), (object)(def_zone) );

			if ( Convert.ToDouble( Proj.damage ) > 0 ) {
				
				if ( !( this.angry != 0 ) ) {
					this.anger( true );
					this.visible_message( new Txt( "<span class='danger'>" ).The( this ).item().str( " roars in rage!</span>" ).ToString() );
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/hallucinations/growl1.ogg", 50, 1 );
				}
			}
			return null;
		}

		// Function from file: mimic.dm
		public override void hitby( Ent_Static AM = null, dynamic speed = null, int? dir = null ) {
			base.hitby( AM, (object)(speed), dir );

			if ( !( this.angry != 0 ) ) {
				this.anger( true );
				this.visible_message( new Txt( "<span class='danger'>" ).The( this ).item().str( " roars in rage!</span>" ).ToString() );
			}
			return;
		}

		// Function from file: mimic.dm
		public virtual void calm_down( bool? change_icon = null ) {
			change_icon = change_icon ?? true;

			
			if ( this.angry > 1 ) {
				return;
			}
			this.angry = 0;

			if ( change_icon == true ) {
				this.icon_state = Lang13.Initial( this, "icon_state" );
			}
			return;
		}

		// Function from file: mimic.dm
		public virtual void anger( bool? berserk = null, bool? change_icon = null ) {
			berserk = berserk ?? false;
			change_icon = change_icon ?? true;

			dynamic C = null;

			this.angry = 1;

			if ( change_icon == true ) {
				
				if ( Lang13.Bool( this.copied_object.IsSubclassOf( typeof(Obj_Structure_Closet) ) ) ) {
					C = this.copied_object;
					this.icon_state = Lang13.Initial( C, "icon_opened" );
				}
			}

			if ( berserk == true ) {
				this.angry = 2;
				this.melee_damage_lower = Lang13.Initial( this, "melee_damage_lower" ) + 4;
				this.melee_damage_upper = Lang13.Initial( this, "melee_damage_upper" ) + 4;
				this.move_to_delay = 0;
				this.name = "" + Lang13.Initial( this, "name" ) + " mimic";
			}
			return;
		}

		// Function from file: mimic.dm
		public override void LostTarget(  ) {
			base.LostTarget();
			this.calm_down();
			return;
		}

		// Function from file: mimic.dm
		public override void LoseTarget(  ) {
			base.LoseTarget();
			this.calm_down();
			return;
		}

		// Function from file: mimic.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( this.angry != 0 ) {
				return base.attack_hand( (object)(a), (object)(b), (object)(c) );
			}
			GlobalFuncs.to_chat( a, "<span class='notice'>It won't budge.</span>" );
			Task13.Schedule( Rand13.Int( 1, 20 ), (Task13.Closure)(() => {
				this.visible_message( new Txt( "<span class='warning'>" ).The( this ).item().str( " starts moving!</span>" ).ToString() );
				this.anger();
				return;
			}));
			return null;
		}

		// Function from file: mimic.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( this.angry != 0 ) {
				return base.attackby( (object)(a), (object)(b), (object)(c) );
			} else {
				return this.attack_hand( b );
			}
		}

		// Function from file: mimic.dm
		public override void Die( bool? gore = null ) {
			dynamic C = null;
			Ent_Dynamic AM = null;

			
			if ( Lang13.Bool( this.copied_object ) ) {
				C = Lang13.Call( this.copied_object, GlobalFuncs.get_turf( this ) );

				foreach (dynamic _a in Lang13.Enumerate( this, typeof(Ent_Dynamic) )) {
					AM = _a;
					
					AM.loc = C;
				}
			}
			base.Die( gore );
			return;
		}

		// Function from file: mimic.dm
		public override bool initialize( bool? suppress_icon_check = null ) {
			Obj_Item I = null;

			base.initialize( suppress_icon_check );

			foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj_Item) )) {
				I = _a;
				

				if ( Lang13.Bool( I.anchored ) || I.density ) {
					continue;
				}
				I.forceMove( this );
			}
			return false;
		}

		// Function from file: mimic.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			this.Die();
			return null;
		}

		// Function from file: mimic.dm
		public override bool Life(  ) {
			bool _default = false;

			bool found_alive_mob = false;
			Mob_Living L = null;

			
			if ( !( this.angry != 0 ) ) {
				
				if ( Convert.ToDouble( this.health ) < Convert.ToDouble( this.maxHealth ) ) {
					this.health = Num13.MinInt( Convert.ToInt32( this.health + 2 ), Convert.ToInt32( this.maxHealth ) );

					if ( this.health == this.maxHealth ) {
						found_alive_mob = false;

						foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( this, 7 ), typeof(Mob_Living) )) {
							L = _a;
							

							if ( L == this ) {
								continue;
							}

							if ( Lang13.Bool( L.stat ) ) {
								continue;
							}
							found_alive_mob = true;
							break;
						}

						if ( !found_alive_mob ) {
							this.environment_disguise();
							this.apply_disguise();
						}
					}
				}

				if ( this.pulledby != null && Rand13.PercentChance( 25 ) ) {
					this.anger();
				} else {
					return _default;
				}
			}
			_default = base.Life();
			return _default;
		}

	}

}