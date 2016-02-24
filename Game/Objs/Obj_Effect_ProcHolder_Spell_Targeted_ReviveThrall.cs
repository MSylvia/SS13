// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_Targeted_ReviveThrall : Obj_Effect_ProcHolder_Spell_Targeted {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.panel = "Shadowling Abilities";
			this.range = 1;
			this.charge_max = 600;
			this.human_req = 1;
			this.clothes_req = 0;
			this.action_icon_state = "revive_thrall";
		}

		public Obj_Effect_ProcHolder_Spell_Targeted_ReviveThrall ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: shadowling_abilities.dm
		public override bool cast( dynamic targets = null, dynamic thearea = null, dynamic user = null ) {
			thearea = thearea ?? Task13.User;

			Mob_Living_Carbon_Human thrallToRevive = null;
			string choice = null;
			int empowered_thralls = 0;
			Mind M = null;
			dynamic H = null;

			
			if ( !this.shadowling_check( thearea ) ) {
				this.revert_cast();
				return false;
			}

			foreach (dynamic _c in Lang13.Enumerate( targets, typeof(Mob_Living_Carbon_Human) )) {
				thrallToRevive = _c;
				
				choice = Interface13.Alert( thearea, "Empower a living thrall or revive a dead one?", null, "Empower", "Revive", "Cancel" );

				switch ((string)( choice )) {
					case "Empower":
						
						if ( !GlobalFuncs.is_thrall( thrallToRevive ) ) {
							thearea.WriteMsg( "<span class='warning'>" + thrallToRevive + " is not a thrall.</span>" );
							this.revert_cast();
							return false;
						}

						if ( thrallToRevive.stat != 0 ) {
							thearea.WriteMsg( "<span class='warning'>" + thrallToRevive + " must be conscious to become empowered.</span>" );
							this.revert_cast();
							return false;
						}
						empowered_thralls = 0;

						foreach (dynamic _a in Lang13.Enumerate( GlobalVars.ticker.mode.thralls, typeof(Mind) )) {
							M = _a;
							

							if ( !( M.current is Mob_Living_Carbon_Human ) ) {
								return false;
							}
							H = M.current;

							if ( H.dna.species.id == "l_shadowling" ) {
								empowered_thralls++;
							}
						}

						if ( empowered_thralls >= 5 ) {
							thearea.WriteMsg( "<span class='warning'>You cannot spare this much energy. There are too many empowered thralls.</span>" );
							this.revert_cast();
							return false;
						}
						((Ent_Static)thearea).visible_message( "<span class='danger'>" + thearea + " places their hands over " + thrallToRevive + "'s face, red light shining from beneath.</span>", "<span class='shadowling'>You place your hands on " + thrallToRevive + "'s face and begin gathering energy...</span>" );
						thrallToRevive.WriteMsg( "<span class='userdanger'>" + thearea + " places their hands over your face. You feel energy gathering. Stand still...</span>" );

						if ( !GlobalFuncs.do_mob( thearea, thrallToRevive, 80 ) ) {
							thearea.WriteMsg( "<span class='warning'>Your concentration snaps. The flow of energy ebbs.</span>" );
							this.revert_cast();
							return false;
						}
						thearea.WriteMsg( "<span class='shadowling'><b><i>You release a massive surge of power into " + thrallToRevive + "!</b></i></span>" );
						((Ent_Static)thearea).visible_message( "<span class='boldannounce'><i>Red lightning surges into " + thrallToRevive + "'s face!</i></span>" );
						GlobalFuncs.playsound( thrallToRevive, "sound/weapons/Egloves.ogg", 50, 1 );
						GlobalFuncs.playsound( thrallToRevive, "sound/machines/defib_zap.ogg", 50, 1 );
						((Ent_Static)thearea).Beam( thrallToRevive, "red_lightning", "icons/effects/effects.dmi", 1 );
						thrallToRevive.Weaken( 5 );
						thrallToRevive.visible_message( "<span class='warning'><b>" + thrallToRevive + " collapses, their skin and face distorting!</span>", "<span class='userdanger'><i>AAAAAAAAAAAAAAAAAAAGH-</i></span>" );
						Task13.Sleep( 20 );
						thrallToRevive.visible_message( "<span class='warning'>" + thrallToRevive + " slowly rises, no longer recognizable as human.</span>", "<span class='shadowling'><b>You feel new power flow into you. You have been gifted by your masters. You now closely resemble them. You are empowered in darkness but wither slowly in light. In addition, Lesser Glare and Guise have been upgraded into their true forms.</b></span>" );
						thrallToRevive.set_species( typeof(Species_Shadow_Ling_Lesser) );
						thrallToRevive.mind.remove_spell( typeof(Obj_Effect_ProcHolder_Spell_Targeted_LesserGlare) );
						thrallToRevive.mind.remove_spell( typeof(Obj_Effect_ProcHolder_Spell_Self_LesserShadowWalk) );
						thrallToRevive.mind.AddSpell( new Obj_Effect_ProcHolder_Spell_Targeted_Glare( null ) );
						thrallToRevive.mind.AddSpell( new Obj_Effect_ProcHolder_Spell_Self_ShadowWalk( null ) );
						break;
					case "Revive":
						
						if ( !GlobalFuncs.is_thrall( thrallToRevive ) ) {
							thearea.WriteMsg( "<span class='warning'>" + thrallToRevive + " is not a thrall.</span>" );
							this.revert_cast();
							return false;
						}

						if ( thrallToRevive.stat != 2 ) {
							thearea.WriteMsg( "<span class='warning'>" + thrallToRevive + " is not dead.</span>" );
							this.revert_cast();
							return false;
						}
						((Ent_Static)thearea).visible_message( new Txt( "<span class='danger'>" ).item( thearea ).str( " kneels over " ).item( thrallToRevive ).str( ", placing their hands on " ).his_her_its_their().str( " chest.</span>" ).ToString(), "<span class='shadowling'>You crouch over the body of your thrall and begin gathering energy...</span>" );
						thrallToRevive.notify_ghost_cloning( "Your masters are resuscitating you! Re-enter your corpse if you wish to be brought to life.", null, thrallToRevive );

						if ( !GlobalFuncs.do_mob( thearea, thrallToRevive, 30 ) ) {
							thearea.WriteMsg( "<span class='warning'>Your concentration snaps. The flow of energy ebbs.</span>" );
							this.revert_cast();
							return false;
						}
						thearea.WriteMsg( "<span class='shadowling'><b><i>You release a massive surge of power into " + thrallToRevive + "!</b></i></span>" );
						((Ent_Static)thearea).visible_message( "<span class='boldannounce'><i>Red lightning surges from " + thearea + "'s hands into " + thrallToRevive + "'s chest!</i></span>" );
						GlobalFuncs.playsound( thrallToRevive, "sound/weapons/Egloves.ogg", 50, 1 );
						GlobalFuncs.playsound( thrallToRevive, "sound/machines/defib_zap.ogg", 50, 1 );
						((Ent_Static)thearea).Beam( thrallToRevive, "red_lightning", "icons/effects/effects.dmi", 1 );
						Task13.Sleep( 10 );
						thrallToRevive.revive();
						thrallToRevive.visible_message( "<span class='boldannounce'>" + thrallToRevive + " heaves in breath, dim red light shining in their eyes.</span>", "<span class='shadowling'><b><i>You have returned. One of your masters has brought you from the darkness beyond.</b></i></span>" );
						thrallToRevive.Weaken( 4 );
						thrallToRevive.emote( "gasp" );
						GlobalFuncs.playsound( thrallToRevive, "bodyfall", 50, 1 );
						break;
					default:
						this.revert_cast();
						return false;
						break;
				}
			}
			return false;
		}

	}

}