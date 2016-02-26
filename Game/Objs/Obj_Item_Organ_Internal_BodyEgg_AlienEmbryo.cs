// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Organ_Internal_BodyEgg_AlienEmbryo : Obj_Item_Organ_Internal_BodyEgg {

		public int stage = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/mob/alien.dmi";
			this.icon_state = "larva0_dead";
		}

		public Obj_Item_Organ_Internal_BodyEgg_AlienEmbryo ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: alien_embryo.dm
		public override void RemoveInfectionImages(  ) {
			Mob_Living_Carbon_Alien alien = null;
			Image I = null;

			
			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Carbon_Alien) )) {
				alien = _b;
				

				if ( alien.client != null ) {
					
					foreach (dynamic _a in Lang13.Enumerate( alien.client.images, typeof(Image) )) {
						I = _a;
						

						if ( GlobalFuncs.dd_hasprefix_case( I.icon_state, "infected" ) != 0 && ((dynamic)I).loc == this.owner ) {
							GlobalFuncs.qdel( I );
						}
					}
				}
			}
			return;
		}

		// Function from file: alien_embryo.dm
		public override void AddInfectionImages(  ) {
			Mob_Living_Carbon_Alien alien = null;
			Image I = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Living_Carbon_Alien) )) {
				alien = _a;
				

				if ( alien.client != null ) {
					I = new Image( "icons/mob/alien.dmi", this.owner, "infected" + this.stage );
					alien.client.images.Add( I );
				}
			}
			return;
		}

		// Function from file: alien_embryo.dm
		public void AttemptGrow( bool? gib_on_success = null ) {
			gib_on_success = gib_on_success ?? true;

			ByTable candidates = null;
			dynamic C = null;
			Image overlay = null;
			dynamic xeno_loc = null;
			Mob_Living_Carbon_Alien_Larva new_xeno = null;

			
			if ( !Lang13.Bool( this.owner ) ) {
				return;
			}
			candidates = GlobalFuncs.get_candidates( "xenomorph", GlobalVars.ALIEN_AFK_BRACKET, "alien candidate" );
			C = null;

			if ( candidates.len != 0 ) {
				C = Rand13.PickFromTable( candidates );
			} else if ( Lang13.Bool( this.owner.client ) && !( GlobalFuncs.jobban_isbanned( this.owner, "alien candidate" ) || GlobalFuncs.jobban_isbanned( this.owner, "Syndicate" ) ) ) {
				C = this.owner.client;
			} else {
				this.stage = 4;
				return;
			}
			overlay = new Image( "icons/mob/alien.dmi", this.owner, "burst_lie" );
			this.owner.overlays += overlay;
			xeno_loc = GlobalFuncs.get_turf( this.owner );
			new_xeno = new Mob_Living_Carbon_Alien_Larva( xeno_loc );
			new_xeno.key = C.key;
			new_xeno.WriteMsg( new Sound( "sound/voice/hiss5.ogg", false, false, 0, 100 ) );
			new_xeno.canmove = false;
			new_xeno.notransform = 1;
			new_xeno.invisibility = 100;
			Task13.Schedule( 6, (Task13.Closure)(() => {
				
				if ( new_xeno != null ) {
					new_xeno.canmove = true;
					new_xeno.notransform = 0;
					new_xeno.invisibility = 0;
				}

				if ( gib_on_success == true ) {
					((Mob)this.owner).gib();
				} else {
					((Mob_Living)this.owner).adjustBruteLoss( 40 );
					this.owner.overlays -= overlay;
				}
				GlobalFuncs.qdel( this );
				return;
			}));
			return;
		}

		// Function from file: alien_embryo.dm
		public override void egg_process(  ) {
			Surgery S = null;

			
			if ( this.stage < 5 && Rand13.PercentChance( 3 ) ) {
				this.stage++;
				Task13.Schedule( 0, (Task13.Closure)(() => {
					this.RefreshInfectionImage();
					return;
				}));
			}

			if ( this.stage == 5 && Rand13.PercentChance( 50 ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.owner.surgeries, typeof(Surgery) )) {
					S = _a;
					

					if ( S.location == "chest" && S.get_surgery_step() is SurgeryStep_ManipulateOrgans ) {
						this.AttemptGrow( false );
						return;
					}
				}
				this.AttemptGrow();
			}
			return;
		}

		// Function from file: alien_embryo.dm
		public override void on_life(  ) {
			
			switch ((int)( this.stage )) {
				case 2:
				case 3:
					
					if ( Rand13.PercentChance( 2 ) ) {
						((Mob)this.owner).emote( "sneeze" );
					}

					if ( Rand13.PercentChance( 2 ) ) {
						((Mob)this.owner).emote( "cough" );
					}

					if ( Rand13.PercentChance( 2 ) ) {
						this.owner.WriteMsg( "<span class='danger'>Your throat feels sore.</span>" );
					}

					if ( Rand13.PercentChance( 2 ) ) {
						this.owner.WriteMsg( "<span class='danger'>Mucous runs down the back of your throat.</span>" );
					}
					break;
				case 4:
					
					if ( Rand13.PercentChance( 2 ) ) {
						((Mob)this.owner).emote( "sneeze" );
					}

					if ( Rand13.PercentChance( 2 ) ) {
						((Mob)this.owner).emote( "cough" );
					}

					if ( Rand13.PercentChance( 4 ) ) {
						this.owner.WriteMsg( "<span class='danger'>Your muscles ache.</span>" );

						if ( Rand13.PercentChance( 20 ) ) {
							((Mob_Living)this.owner).take_organ_damage( 1 );
						}
					}

					if ( Rand13.PercentChance( 4 ) ) {
						this.owner.WriteMsg( "<span class='danger'>Your stomach hurts.</span>" );

						if ( Rand13.PercentChance( 20 ) ) {
							((Mob_Living)this.owner).adjustToxLoss( 1 );
						}
					}
					break;
				case 5:
					this.owner.WriteMsg( "<span class='danger'>You feel something tearing its way out of your stomach...</span>" );
					((Mob_Living)this.owner).adjustToxLoss( 10 );
					break;
			}
			return;
		}

		// Function from file: alien_embryo.dm
		public override Obj_Item_Weapon_ReagentContainers_Food_Snacks_Organ prepare_eat(  ) {
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Organ S = null;

			S = base.prepare_eat();
			S.reagents.add_reagent( "sacid", 10 );
			return S;
		}

		// Function from file: alien_embryo.dm
		public override void on_find( dynamic finder = null ) {
			base.on_find( (object)(finder) );

			if ( this.stage < 4 ) {
				finder.WriteMsg( "It's small and weak, barely the size of a foetus." );
			} else {
				finder.WriteMsg( "It's grown quite large, and writhes slightly as you look at it." );

				if ( Rand13.PercentChance( 10 ) ) {
					this.AttemptGrow( false );
				}
			}
			return;
		}

	}

}