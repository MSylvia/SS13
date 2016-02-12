// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Immovablerod : Obj_Item_Projectile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.throwforce = 100;
			this.locked_atoms = new ByTable();
			this.grillepasschance = 0;
			this.icon = "icons/obj/objects.dmi";
			this.icon_state = "immrod";
		}

		// Function from file: immovablerod.dm
		public Obj_Item_Projectile_Immovablerod ( dynamic start = null, Tile end = null ) : base( (object)(start) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.step_delay = Num13.Round( 0.5, Game13.tick_lag );

			if ( end != null ) {
				this.throw_at( end );
			}
			return;
		}

		// Function from file: immovablerod.dm
		public void clong(  ) {
			GlobalFuncs.playsound( this, "sound/effects/bang.ogg", 50, 1 );
			this.visible_message( "CLANG" );
			return;
		}

		// Function from file: immovablerod.dm
		public override bool forceMove( dynamic destination = null, int? no_tp = null ) {
			no_tp = no_tp ?? 0;

			Ent_Static clong = null;
			Ent_Static H = null;

			base.forceMove( (object)(destination), no_tp );

			if ( this.z != Convert.ToInt32( this.starting.z ) ) {
				GlobalFuncs.qdel( this );
				return false;
			}

			if ( this.loc.density ) {
				this.loc.ex_act( 2 );

				if ( Rand13.PercentChance( 25 ) ) {
					this.clong();
				}
			}

			foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Ent_Static) )) {
				clong = _a;
				

				if ( !clong.density ) {
					continue;
				}

				if ( clong is Obj ) {
					
					if ( clong.density ) {
						clong.ex_act( 1 );
					}
				} else if ( clong is Mob ) {
					
					if ( clong is Mob_Living_Carbon_Human ) {
						H = clong;
						H.visible_message( "<span class='danger'>" + H.name + " is penetrated by an immovable rod!</span>", "<span class='userdanger'>The rod penetrates you!</span>", "<span class ='danger'>You hear a CLANG!</span>" );
						((dynamic)H).gib();
					} else if ( clong.density || clong is Mob_Living && Rand13.PercentChance( 10 ) ) {
						clong.visible_message( "<span class='danger'>" + clong + " is scraped by an immovable rod!</span>", "<span class='userdanger'>The rod scrapes part of you off!</span>", "<span class ='danger'>You hear a CLANG!</span>" );
						clong.ex_act( 2 );
					}
				}

				if ( Rand13.PercentChance( 25 ) && ( !( clong != null ) || !clong.density || Lang13.Bool( clong.gcDestroyed ) ) ) {
					this.clong();
				}
			}
			return false;
		}

		// Function from file: immovablerod.dm
		public override dynamic bresenham_step( double distA = 0, double distB = 0, double? dA = null, double? dB = null, Ent_Static lastposition = null, double? target_dir = null, dynamic reference = null ) {
			Tile newloc = null;
			Tile newloc2 = null;

			
			if ( this.step_delay != 0 ) {
				Task13.Sleep( ((int)( this.step_delay )) );
			}

			if ( this.error < 0 ) {
				newloc = Map13.GetStep( this, ((int)( dB ??0 )) );

				if ( !( newloc != null ) ) {
					this.bullet_die();
				}
				this.forceMove( newloc );
				this.error += distA;
				return 0;
			} else {
				newloc2 = Map13.GetStep( this, ((int)( dA ??0 )) );

				if ( !( newloc2 != null ) ) {
					this.bullet_die();
				}
				this.forceMove( newloc2 );
				this.error -= distB;
				return 1;
			}
		}

		// Function from file: immovablerod.dm
		public override double singularity_act( double? current_size = null, Obj_Machinery_Singularity S = null ) {
			S.expand( 9 );
			GlobalFuncs.qdel( this );
			return 0;
		}

		// Function from file: immovablerod.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			return false;
		}

		// Function from file: immovablerod.dm
		public override bool throw_at( dynamic target = null, double? range = null, dynamic speed = null, bool? _override = null ) {
			Mob_Dead_Observer people = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.observers, typeof(Mob_Dead_Observer) )) {
				people = _a;
				
				GlobalFuncs.to_chat( people, new Txt( "<span class = 'notice'>Immovable rod has been thrown at the station, <a href='?src=" ).Ref( people ).str( ";follow=" ).Ref( this ).str( "'>Follow it</a></span>" ).ToString() );
			}
			this.original = target;
			this.starting = this.loc;
			this.current = this.loc;
			this.OnFired();
			this.yo = Convert.ToDouble( this.target.y - this.y );
			this.xo = Convert.ToDouble( this.target.x - this.x );
			this.process();
			return false;
		}

	}

}