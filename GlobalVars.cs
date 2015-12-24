using System;
using Som13;

namespace Game13 {
	static class GlobalVars {
		public static readonly JsonReader _jsonr = new JsonReader();
		public static readonly JsonWriter _jsonw = new JsonWriter();
		public static DmmSuite_Preloader _preloader = null;
		public static Ent_Screen_ClickCatcher _void = null;
		public static readonly int AALARM_WIRE_IDSCAN = 1;
		public static dynamic abandon_allowed = 1;
		public static readonly int access_ai_upload = 16;
		public static readonly int access_all_personal_lockers = 21;
		public static readonly int access_armory = 3;
		public static readonly int access_atmospherics = 24;
		public static readonly int access_bar = 25;
		public static readonly int access_brig = 2;
		public static readonly int access_captain = 20;
		public static readonly int access_cargo = 31;
		public static readonly int access_ce = 56;
		public static readonly int access_cent_captain = 109;
		public static readonly int access_cent_general = 101;
		public static readonly int access_cent_living = 105;
		public static readonly int access_cent_medical = 104;
		public static readonly int access_cent_specops = 103;
		public static readonly int access_cent_storage = 106;
		public static readonly int access_cent_teleporter = 107;
		public static readonly int access_cent_thunder = 102;
		public static readonly int access_change_ids = 15;
		public static readonly int access_chapel_office = 22;
		public static readonly int access_chemistry = 33;
		public static readonly int access_cmo = 40;
		public static readonly int access_construction = 32;
		public static readonly int access_court = 42;
		public static readonly int access_crematorium = 27;
		public static readonly int access_engine = 10;
		public static readonly int access_engine_equip = 11;
		public static readonly int access_eva = 18;
		public static readonly int access_external_airlocks = 13;
		public static readonly int access_forensics_lockers = 4;
		public static readonly int access_gateway = 62;
		public static readonly int access_genetics = 9;
		public static readonly int access_heads = 19;
		public static readonly int access_heads_vault = 53;
		public static readonly int access_hop = 57;
		public static readonly int access_hos = 58;
		public static readonly int access_hydroponics = 35;
		public static readonly int access_janitor = 26;
		public static readonly int access_keycard_auth = 60;
		public static readonly int access_kitchen = 28;
		public static readonly int access_lawyer = 38;
		public static readonly int access_library = 37;
		public static readonly int access_mailsorting = 50;
		public static readonly int access_maint_tunnels = 12;
		public static readonly int access_medical = 5;
		public static readonly int access_mineral_storeroom = 64;
		public static readonly int access_mining = 48;
		public static readonly int access_mining_station = 54;
		public static readonly int access_minisat = 65;
		public static readonly int access_morgue = 6;
		public static readonly int access_qm = 41;
		public static readonly int access_RC_announce = 59;
		public static readonly int access_rd = 30;
		public static readonly int access_research = 47;
		public static readonly int access_robotics = 29;
		public static readonly int access_sec_doors = 63;
		public static readonly int access_security = 1;
		public static readonly int access_surgery = 45;
		public static readonly int access_syndicate = 150;
		public static readonly int access_syndicate_leader = 151;
		public static readonly int access_tcomsat = 61;
		public static readonly int access_tech_storage = 23;
		public static readonly int access_teleporter = 17;
		public static readonly int access_theatre = 46;
		public static readonly int access_tox = 7;
		public static readonly int access_tox_storage = 8;
		public static readonly int access_virology = 39;
		public static readonly int access_weapons = 66;
		public static readonly int access_xenobiology = 55;
		public static readonly ByTable accessable_z_levels = new ByTable(new object [] { 1, 3, 4, 5, 6, 7 });
		public static ByTable active_turfs_startlist = new ByTable();
		public static readonly dynamic adjectives = GlobalFuncs.file2list( "config/names/adjectives.txt" );
		public static ByTable admin_datums = new ByTable();
		public static readonly ByTable admin_log = new ByTable();
		public static string admin_notice = "";
		public static ByTable admin_ranks = new ByTable();
		public static dynamic admin_sound = null;
		public static readonly ByTable admin_verbs_admin = new ByTable(new object [] { typeof(Client).GetMethod( "player_panel_new" ), typeof(Client).GetMethod( "invisimin" ), typeof(Admins).GetMethod( "show_player_panel" ), typeof(Client).GetMethod( "game_panel" ), typeof(Client).GetMethod( "check_ai_laws" ), typeof(Admins).GetMethod( "toggleooc" ), typeof(Admins).GetMethod( "toggleoocdead" ), typeof(Admins).GetMethod( "toggleenter" ), typeof(Admins).GetMethod( "toggleguests" ), typeof(Admins).GetMethod( "announce" ), typeof(Admins).GetMethod( "set_admin_notice" ), typeof(Client).GetMethod( "admin_ghost" ), typeof(Client).GetMethod( "toggle_view_range" ), typeof(Admins).GetMethod( "view_txt_log" ), typeof(Admins).GetMethod( "view_atk_log" ), typeof(Client).GetMethod( "cmd_admin_subtle_message" ), typeof(Client).GetMethod( "cmd_admin_delete" ), typeof(Client).GetMethod( "cmd_admin_check_contents" ), typeof(Client).GetMethod( "check_antagonists" ), typeof(Admins).GetMethod( "access_news_network" ), typeof(Client).GetMethod( "giveruntimelog" ), typeof(Client).GetMethod( "getruntimelog" ), typeof(Client).GetMethod( "getserverlog" ), typeof(Client).GetMethod( "jumptocoord" ), typeof(Client).GetMethod( "Getmob" ), typeof(Client).GetMethod( "Getkey" ), typeof(Client).GetMethod( "jumptoarea" ), typeof(Client).GetMethod( "jumptokey" ), typeof(Client).GetMethod( "jumptomob" ), typeof(Client).GetMethod( "jumptoturf" ), typeof(Client).GetMethod( "admin_call_shuttle" ), typeof(Client).GetMethod( "admin_cancel_shuttle" ), typeof(Client).GetMethod( "cmd_admin_direct_narrate" ), typeof(Client).GetMethod( "cmd_admin_world_narrate" ), typeof(Client).GetMethod( "cmd_admin_local_narrate" ), typeof(Client).GetMethod( "cmd_admin_create_centcom_report" ), typeof(Client).GetMethod( "toggle_antag_hud" ) });
		public static readonly ByTable admin_verbs_ban = new ByTable(new object [] { typeof(Client).GetMethod( "unban_panel" ), typeof(Client).GetMethod( "jobbans" ), typeof(Client).GetMethod( "unjobban_panel" ), typeof(Client).GetMethod( "DB_ban_panel" ), typeof(Client).GetMethod( "stickybanpanel" ) });
		public static readonly ByTable admin_verbs_debug = new ByTable(new object [] { typeof(Client).GetMethod( "restart_controller" ), typeof(Client).GetMethod( "cmd_admin_list_open_jobs" ), typeof(Client).GetMethod( "Debug2" ), typeof(Client).GetMethod( "cmd_debug_make_powernets" ), typeof(Client).GetMethod( "debug_controller" ), typeof(Client).GetMethod( "cmd_debug_mob_lists" ), typeof(Client).GetMethod( "cmd_admin_delete" ), typeof(Client).GetMethod( "cmd_debug_del_all" ), typeof(Client).GetMethod( "restart_controller" ), typeof(Client).GetMethod( "enable_debug_verbs" ), typeof(Client).GetMethod( "callproc" ), typeof(Client).GetMethod( "callproc_datum" ), typeof(Client).GetMethod( "SDQL2_query" ), typeof(Client).GetMethod( "test_movable_UI" ), typeof(Client).GetMethod( "test_snap_UI" ), typeof(Client).GetMethod( "debugNatureMapGenerator" ), typeof(Client).GetMethod( "check_bomb_impacts" ), typeof(GlobalFuncs).GetMethod( "machine_upgrade" ), typeof(Client).GetMethod( "populate_world" ), typeof(Client).GetMethod( "cmd_display_del_log" ), typeof(Client).GetMethod( "reset_latejoin_spawns" ), typeof(Client).GetMethod( "create_outfits" ), typeof(Client).GetMethod( "debug_huds" ) });
		public static readonly ByTable admin_verbs_default = new ByTable(new object [] { typeof(Client).GetMethod( "toggleadminhelpsound" ), typeof(Client).GetMethod( "toggleannouncelogin" ), typeof(Client).GetMethod( "deadmin_self" ), typeof(Client).GetMethod( "cmd_admin_say" ), typeof(Client).GetMethod( "hide_verbs" ), typeof(Client).GetMethod( "hide_most_verbs" ), typeof(Client).GetMethod( "debug_variables" ), typeof(Client).GetMethod( "admin_memo" ), typeof(Client).GetMethod( "deadchat" ), typeof(Client).GetMethod( "dsay" ), typeof(Client).GetMethod( "toggleprayers" ), typeof(Client).GetMethod( "toggleprayersounds" ), typeof(Client).GetMethod( "toggle_hear_radio" ), typeof(Client).GetMethod( "investigate_show" ), typeof(Client).GetMethod( "secrets" ), typeof(Client).GetMethod( "reload_admins" ), typeof(Client).GetMethod( "reestablish_db_connection" ), typeof(Client).GetMethod( "cmd_admin_pm_context" ), typeof(Client).GetMethod( "cmd_admin_pm_panel" ), typeof(Client).GetMethod( "stop_sounds" ) });
		public static readonly ByTable admin_verbs_fun = new ByTable(new object [] { typeof(Client).GetMethod( "cmd_admin_dress" ), typeof(Client).GetMethod( "cmd_admin_gib_self" ), typeof(Client).GetMethod( "drop_bomb" ), typeof(Client).GetMethod( "cinematic" ), typeof(Client).GetMethod( "one_click_antag" ), typeof(Client).GetMethod( "send_space_ninja" ), typeof(Client).GetMethod( "cmd_admin_add_freeform_ai_law" ), typeof(Client).GetMethod( "cmd_admin_add_random_ai_law" ), typeof(Client).GetMethod( "object_say" ), typeof(Client).GetMethod( "toggle_random_events" ), typeof(Client).GetMethod( "set_ooc" ), typeof(Client).GetMethod( "reset_ooc" ), typeof(Client).GetMethod( "forceEvent" ), typeof(Client).GetMethod( "bluespace_artillery" ), typeof(Client).GetMethod( "admin_change_sec_level" ), typeof(Client).GetMethod( "toggle_nuke" ) });
		public static readonly ByTable admin_verbs_hideable = new ByTable(new object [] { typeof(Client).GetMethod( "set_ooc" ), typeof(Client).GetMethod( "reset_ooc" ), typeof(Client).GetMethod( "deadmin_self" ), typeof(Client).GetMethod( "deadchat" ), typeof(Client).GetMethod( "toggleprayers" ), typeof(Client).GetMethod( "toggle_hear_radio" ), typeof(Admins).GetMethod( "show_traitor_panel" ), typeof(Admins).GetMethod( "toggleenter" ), typeof(Admins).GetMethod( "toggleguests" ), typeof(Admins).GetMethod( "announce" ), typeof(Admins).GetMethod( "set_admin_notice" ), typeof(Client).GetMethod( "admin_ghost" ), typeof(Client).GetMethod( "toggle_view_range" ), typeof(Admins).GetMethod( "view_txt_log" ), typeof(Admins).GetMethod( "view_atk_log" ), typeof(Client).GetMethod( "cmd_admin_subtle_message" ), typeof(Client).GetMethod( "cmd_admin_check_contents" ), typeof(Admins).GetMethod( "access_news_network" ), typeof(Client).GetMethod( "admin_call_shuttle" ), typeof(Client).GetMethod( "admin_cancel_shuttle" ), typeof(Client).GetMethod( "cmd_admin_direct_narrate" ), typeof(Client).GetMethod( "cmd_admin_world_narrate" ), typeof(Client).GetMethod( "cmd_admin_local_narrate" ), typeof(Client).GetMethod( "play_local_sound" ), typeof(Client).GetMethod( "play_sound" ), typeof(Client).GetMethod( "set_round_end_sound" ), typeof(Client).GetMethod( "cmd_admin_dress" ), typeof(Client).GetMethod( "cmd_admin_gib_self" ), typeof(Client).GetMethod( "drop_bomb" ), typeof(Client).GetMethod( "cinematic" ), typeof(Client).GetMethod( "send_space_ninja" ), typeof(Client).GetMethod( "cmd_admin_add_freeform_ai_law" ), typeof(Client).GetMethod( "cmd_admin_add_random_ai_law" ), typeof(Client).GetMethod( "cmd_admin_create_centcom_report" ), typeof(Client).GetMethod( "object_say" ), typeof(Client).GetMethod( "toggle_random_events" ), typeof(Client).GetMethod( "cmd_admin_add_random_ai_law" ), typeof(Admins).GetMethod( "startnow" ), typeof(Admins).GetMethod( "restart" ), typeof(Admins).GetMethod( "delay" ), typeof(Admins).GetMethod( "toggleaban" ), typeof(Client).GetMethod( "toggle_log_hrefs" ), typeof(Client).GetMethod( "everyone_random" ), typeof(Admins).GetMethod( "toggleAI" ), typeof(Client).GetMethod( "restart_controller" ), typeof(Client).GetMethod( "cmd_admin_list_open_jobs" ), typeof(Client).GetMethod( "callproc" ), typeof(Client).GetMethod( "callproc_datum" ), typeof(Client).GetMethod( "Debug2" ), typeof(Client).GetMethod( "reload_admins" ), typeof(Client).GetMethod( "cmd_debug_make_powernets" ), typeof(Client).GetMethod( "debug_controller" ), typeof(Client).GetMethod( "startSinglo" ), typeof(Client).GetMethod( "cmd_debug_mob_lists" ), typeof(Client).GetMethod( "cmd_debug_del_all" ), typeof(Client).GetMethod( "enable_debug_verbs" ), typeof(GlobalFuncs).GetMethod( "possess" ), typeof(GlobalFuncs).GetMethod( "release" ), typeof(Client).GetMethod( "reload_admins" ), typeof(Client).GetMethod( "panicbunker" ), typeof(Client).GetMethod( "admin_change_sec_level" ), typeof(Client).GetMethod( "toggle_nuke" ), typeof(Client).GetMethod( "cmd_display_del_log" ), typeof(Client).GetMethod( "toggle_antag_hud" ), typeof(Client).GetMethod( "debug_huds" ) });
		public static readonly ByTable admin_verbs_permissions = new ByTable(new object [] { typeof(Client).GetMethod( "edit_admin_permissions" ), typeof(Client).GetMethod( "create_poll" ) });
		public static readonly ByTable admin_verbs_possess = new ByTable(new object [] { typeof(GlobalFuncs).GetMethod( "possess" ), typeof(GlobalFuncs).GetMethod( "release" ) });
		public static readonly ByTable admin_verbs_rejuv = new ByTable(new object [] { typeof(Client).GetMethod( "respawn_character" ) });
		public static readonly ByTable admin_verbs_server = new ByTable(new object [] { typeof(Admins).GetMethod( "startnow" ), typeof(Admins).GetMethod( "restart" ), typeof(Admins).GetMethod( "end_round" ), typeof(Admins).GetMethod( "delay" ), typeof(Admins).GetMethod( "toggleaban" ), typeof(Client).GetMethod( "toggle_log_hrefs" ), typeof(Client).GetMethod( "everyone_random" ), typeof(Admins).GetMethod( "toggleAI" ), typeof(Client).GetMethod( "cmd_admin_delete" ), typeof(Client).GetMethod( "cmd_debug_del_all" ), typeof(Client).GetMethod( "toggle_random_events" ), typeof(Client).GetMethod( "panicbunker" ) });
		public static readonly ByTable admin_verbs_sounds = new ByTable(new object [] { typeof(Client).GetMethod( "play_local_sound" ), typeof(Client).GetMethod( "play_sound" ), typeof(Client).GetMethod( "set_round_end_sound" ) });
		public static readonly ByTable admin_verbs_spawn = new ByTable(new object [] { typeof(Admins).GetMethod( "spawn_atom" ), typeof(Client).GetMethod( "respawn_character" ) });
		public static readonly ByTable adminlog = new ByTable();
		public static ByTable admins = new ByTable();
		public static readonly ByTable advance_cures = new ByTable(new object [] { "sodiumchloride", "sugar", "orangejuice", "spaceacillin", "salglu_solution", "ethanol", "leporazine", "synaptizine", "lipolicide", "silver", "gold" });
		public static readonly int agents_possible = 5;
		public static ByTable ai_list = new ByTable();
		public static readonly dynamic ai_names = GlobalFuncs.file2list( "config/names/ai.txt" );
		public static readonly int AIPRIV_FREQ = 1447;
		public static readonly ByTable airlock_overlays = new ByTable();
		public static readonly int AIRLOCK_WIRE_BACKUP_POWER1 = 16;
		public static readonly int AIRLOCK_WIRE_BACKUP_POWER2 = 32;
		public static readonly int AIRLOCK_WIRE_DOOR_BOLTS = 8;
		public static readonly int AIRLOCK_WIRE_ELECTRIFY = 256;
		public static readonly int AIRLOCK_WIRE_IDSCAN = 1;
		public static readonly int AIRLOCK_WIRE_LIGHT = 2048;
		public static readonly int AIRLOCK_WIRE_MAIN_POWER1 = 2;
		public static readonly int AIRLOCK_WIRE_MAIN_POWER2 = 4;
		public static readonly int AIRLOCK_WIRE_OPEN_DOOR = 64;
		public static readonly int AIRLOCK_WIRE_SAFETY = 512;
		public static readonly int AIRLOCK_WIRE_SPEED = 1024;
		public static ByTable airlocks = new ByTable();
		public static readonly int ALIEN_AFK_BRACKET = 450;
		public static readonly ByTable all_radios = new ByTable();
		public static readonly ByTable all_supply_groups = new ByTable(new object [] { GlobalVars.supply_emergency, GlobalVars.supply_security, GlobalVars.supply_engineer, GlobalVars.supply_medical, GlobalVars.supply_science, GlobalVars.supply_organic, GlobalVars.supply_materials, GlobalVars.supply_misc });
		public static ByTable allCasters = new ByTable();
		public static ByTable allConsoles = new ByTable();
		public static readonly ByTable alldirs = new ByTable(new object [] { GlobalVars.NORTH, GlobalVars.SOUTH, GlobalVars.EAST, GlobalVars.WEST, GlobalVars.NORTHEAST, GlobalVars.NORTHWEST, GlobalVars.SOUTHEAST, GlobalVars.SOUTHWEST });
		public static readonly ByTable allowed_items = new ByTable().set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Blumpkin), "blumpkinjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Pumpkin), "pumpkinjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Berries_Poison), "poisonberryjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Watermelonslice), "watermelonjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Watermelon), "watermelonjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Citrus_Lime), "limejuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Citrus_Orange), "orangejuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Citrus_Lemon), "lemonjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Potato), "potato" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Banana), "banana" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Grapes_Green), "grapejuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Grapes), "grapejuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Berries), "berryjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Carrot), "carrotjuice" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato), "tomatojuice" );
		public static readonly ByTable alphabet = new ByTable(new object [] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z" });
		public static readonly ByTable animated_spines_list = new ByTable();
		public static readonly ByTable animated_tails_list_human = new ByTable();
		public static readonly ByTable animated_tails_list_lizard = new ByTable();
		public static ByTable announcement_systems = new ByTable();
		public static double announcing_vox = 0;
		public static readonly int APC_WIRE_AI_CONTROL = 8;
		public static readonly int APC_WIRE_MAIN_POWER1 = 2;
		public static readonly int APC_WIRE_MAIN_POWER2 = 4;
		public static ByTable apcs_list = new ByTable();
		public static readonly ByTable appearance_keylist = new ByTable( 0 );
		public static readonly ByTable archive_diseases = new ByTable();
		public static readonly int AREA_SPACE = 2;
		public static readonly int AREA_SPECIAL = 3;
		public static readonly int AREA_STATION = 1;
		public static readonly ByTable assistant_occupations = new ByTable(new object [] { "Assistant", "Atmospheric Technician", "Cargo Technician", "Chaplain", "Lawyer", "Librarian" });
		public static readonly ByTable awaydestinations = new ByTable();
		public static readonly ByTable backbaglist = new ByTable(new object [] { "Backpack", "Satchel" });
		public static ByTable bad_mutations = new ByTable();
		public static readonly dynamic bad_se_blocks = null;
		public static readonly dynamic Banlist = null;
		public static readonly dynamic Banlistjob = null;
		public static readonly ByTable be_special_flags = new ByTable().set( "Shadowling", 8192 ).set( "Revenant", 32768 ).set( "Abductor", 16384 ).set( "Gang", 4096 ).set( "Monkey", 2048 ).set( "Ninja", 1024 ).set( "Blob", 512 ).set( "Cultist", 256 ).set( "pAI", 128 ).set( "Alien Lifeform", 64 ).set( "Revolutionary", 32 ).set( "Malf AI", 16 ).set( "Wizard", 8 ).set( "Changeling", 4 ).set( "Operative", 2 ).set( "Traitor", 1 );
		public static readonly ByTable bibleitemstates = new ByTable(new object [] { "bible", "koran", "scrapbook", "bible", "bible", "bible", "syringe_kit", "syringe_kit", "syringe_kit", "syringe_kit", "syringe_kit", "kingyellow", "ithaqua", "scientology", "melted", "necronomicon" });
		public static readonly ByTable biblenames = new ByTable(new object [] { "Bible", "Quran", "Scrapbook", "Burning Bible", "Clown Bible", "Banana Bible", "Creeper Bible", "White Bible", "Holy Light", "The God Delusion", "Tome", "The King in Yellow", "Ithaqua", "Scientology", "Melted Bible", "Necronomicon" });
		public static readonly ByTable biblestates = new ByTable(new object [] { "bible", "koran", "scrapbook", "burning", "honk1", "honk2", "creeper", "white", "holylight", "atheist", "tome", "kingyellow", "ithaqua", "scientology", "melted", "necronomicon" });
		public static readonly ByTable binary = new ByTable(new object [] { "0", "1" });
		public static Ent_Machinery_BlackboxRecorder blackbox = null;
		public static readonly int BLEND_ADD = 2;
		public static readonly int BLEND_DEFAULT = 0;
		public static readonly int BLEND_MULTIPLY = 4;
		public static readonly int BLEND_OVERLAY = 1;
		public static ByTable blob_cores = new ByTable();
		public static ByTable blob_nodes = new ByTable();
		public static ByTable blobs = new ByTable();
		public static ByTable blobstart = new ByTable();
		public static readonly ByTable blood_splatter_icons = new ByTable();
		public static readonly int BLOOD_VOLUME_SAFE = 501;
		public static readonly ByTable bloody_footprints_cache = new ByTable();
		public static readonly ByTable body_markings_list = new ByTable();
		public static int bomb_set = 0;
		public static ByTable bombers = new ByTable();
		public static readonly int BORDER_2NDTILE = 3;
		public static readonly int BORDER_BETWEEN = 2;
		public static readonly int BORDER_NONE = 1;
		public static readonly int BORDER_SPACE = 4;
		public static ByTable BUMP_TELEPORTERS = new ByTable();
		public static readonly ByTable cable_coil_recipes = new ByTable(new object [] { new StackRecipe( "cable restraints", typeof(Ent_Item_Weapon_Restraints_Handcuffs_Cable), 15 ) });
		public static ByTable cable_list = new ByTable();
		public static ByTable cachedbooks = null;
		public static readonly int CALL_SHUTTLE_REASON_LENGTH = 12;
		public static readonly Cameranet cameranet = new Cameranet();
		public static readonly ByTable cardboard_recipes = new ByTable(new object [] { new StackRecipe( "box", typeof(Ent_Item_Weapon_Storage_Box) ), new StackRecipe( "light tubes", typeof(Ent_Item_Weapon_Storage_Box_Lights_Tubes) ), new StackRecipe( "light bulbs", typeof(Ent_Item_Weapon_Storage_Box_Lights_Bulbs) ), new StackRecipe( "mouse traps", typeof(Ent_Item_Weapon_Storage_Box_Mousetraps) ), new StackRecipe( "cardborg suit", typeof(Ent_Item_Clothing_Suit_Cardborg), 3 ), new StackRecipe( "cardborg helmet", typeof(Ent_Item_Clothing_Head_Cardborg) ), new StackRecipe( "pizza box", typeof(Ent_Item_Pizzabox) ), new StackRecipe( "folder", typeof(Ent_Item_Weapon_Folder) ), new StackRecipe( "large box", typeof(Ent_Structure_Closet_Cardboard), 4 ) });
		public static readonly ByTable cardinal = new ByTable(new object [] { GlobalVars.NORTH, GlobalVars.SOUTH, GlobalVars.EAST, GlobalVars.WEST });
		public static readonly double CELLRATE = 0.0020000000949949026;
		public static readonly int CENTCOM_FREQ = 1337;
		public static readonly int changeling_amount = 4;
		public static readonly string changelog_hash = "";
		public static readonly double CHARGELEVEL = 0.0010000000474974513;
		public static readonly ByTable chatchannels = new ByTable().set( GlobalVars.default_ntrc_chatroom.name, GlobalVars.default_ntrc_chatroom );
		public static ByTable chemical_mob_spawn_meancritters = new ByTable();
		public static ByTable chemical_mob_spawn_nicecritters = new ByTable();
		public static ByTable chemical_reactions_list = null;
		public static ByTable chemical_reagents_list = null;
		public static int chicken_count = 0;
		public static readonly int CHUNK_SIZE = 16;
		public static readonly int CIVILIAN = 4;
		public static readonly ByTable civilian_positions = new ByTable(new object [] { "Bartender", "Botanist", "Cook", "Janitor", "Librarian", "Lawyer", "Chaplain", "Clown", "Mime", "Assistant" });
		public static readonly int CLAMPED_OFF = 1;
		public static readonly ByTable clientmessages = new ByTable();
		public static ByTable clients = new ByTable();
		public static readonly int CLOSE_DURATION = 6;
		public static readonly int CLOSED = 2;
		public static readonly dynamic clown_names = GlobalFuncs.file2list( "config/names/clown.txt" );
		public static readonly ByTable clown_recipes = new ByTable(new object [] { new StackRecipe( "bananium tile", typeof(Ent_Item_Stack_Tile_Mineral_Bananium), 1, 4, 20 ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Bananium_Clown) ).set( 1, "Clown Statue" ).applyCtor( typeof(StackRecipe) ) });
		public static dynamic CMinutes = null;
		public static dynamic cmp_field = "name";
		public static readonly ByTable combatlog = new ByTable();
		public static readonly int COMM_FREQ = 1353;
		public static string command_name = "";
		public static readonly ByTable command_positions = new ByTable(new object [] { "Captain", "Head of Personnel", "Head of Security", "Chief Engineer", "Research Director", "Chief Medical Officer" });
		public static readonly dynamic commando_names = GlobalFuncs.file2list( "config/names/death_commando.txt" );
		public static readonly ByTable common_tools = new ByTable(new object [] { typeof(Ent_Item_Stack_CableCoil), typeof(Ent_Item_Weapon_Wrench), typeof(Ent_Item_Weapon_Weldingtool), typeof(Ent_Item_Weapon_Screwdriver), typeof(Ent_Item_Weapon_Wirecutters), typeof(Ent_Item_Device_Multitool), typeof(Ent_Item_Weapon_Crowbar) });
		public static int comms_allowed = 0;
		public static dynamic comms_key = "default_pwd";
		public static readonly dynamic config = null;
		public static readonly ByTable contrabandposters = new ByTable(new object [] { 
			new ByTable().set( "desc", " A salvaged shred of a much larger flag, colors bled together and faded from age." ).set( "name", "- Free Tonto" ), 
			new ByTable().set( "desc", " A relic of a failed rebellion." ).set( "name", "- Atmosia Declaration of Independence" ), 
			new ByTable().set( "desc", " A poster condemning the station's security forces." ).set( "name", "- Fun Police" ), 
			new ByTable().set( "desc", " A heretical poster depicting the titular star of an equally heretical book." ).set( "name", "- Lusty Xenomorph" ), 
			new ByTable().set( "desc", " See the galaxy! Shatter corrupt megacorporations! Join today!" ).set( "name", "- Syndicate Recruitment" ), 
			new ByTable().set( "desc", " Honk." ).set( "name", "- Clown" ), 
			new ByTable().set( "desc", " A poster advertising a rival corporate brand of cigarettes." ).set( "name", "- Smoke" ), 
			new ByTable().set( "desc", " A rebellious poster symbolizing assistant solidarity." ).set( "name", "- Grey Tide" ), 
			new ByTable().set( "desc", " This poster references the uproar that followed Nanotrasen's financial cuts toward insulated-glove purchases." ).set( "name", "- Missing Gloves" ), 
			new ByTable().set( "desc", " This poster details the internal workings of the common Nanotrasen airlock. Sadly, it appears out of date." ).set( "name", "- Hacking Guide" ), 
			new ByTable().set( "desc", " This seditious poster references Nanotrasen's genocide of a space station full of badgers." ).set( "name", "- RIP Badger" ), 
			new ByTable().set( "desc", " This poster is lookin' pretty trippy man." ).set( "name", "- Ambrosia Vulgaris" ), 
			new ByTable().set( "desc", " This poster is an unauthorized advertisement for Donut Corp." ).set( "name", "- Donut Corp." ), 
			new ByTable().set( "desc", " This poster promotes rank gluttony." ).set( "name", "- EAT." ), 
			new ByTable().set( "desc", " This poster looks like an advertisement for tools, but is in fact a subliminal jab at the tools at CentComm." ).set( "name", "- Tools" ), 
			new ByTable().set( "desc", " A poster that positions the seat of power outside Nanotrasen." ).set( "name", "- Power" ), 
			new ByTable().set( "desc", " Ignorant of Nature's Harmonic 6 Side Space Cube Creation, the Spacemen are Dumb, Educated Singularity Stupid and Evil." ).set( "name", "- Space Cube" ), 
			new ByTable().set( "desc", " All hail the Communist party!" ).set( "name", "- Communist State" ), 
			new ByTable().set( "desc", " This poster depicts Lamarr. Probably made by a traitorous Research Director." ).set( "name", "- Lamarr" ), 
			new ByTable().set( "desc", " Being fancy can be for any borg, just need a suit." ).set( "name", "- Borg Fancy" ), 
			new ByTable().set( "desc", " Borg Fancy, Now only taking the most fancy." ).set( "name", "- Borg Fancy v2" ), 
			new ByTable().set( "desc", " A poster mocking CentComm's denial of the existence of the derelict station near Space Station 13." ).set( "name", "- Kosmicheskaya Stantsiya 13 Does Not Exist" ), 
			new ByTable().set( "desc", " A poster urging the viewer to rebel against Nanotrasen." ).set( "name", "- Rebels Unite" ), 
			new ByTable().set( "desc", " A poster advertising the Scarborough Arms C-20r." ).set( "name", "- C-20r" ), 
			new ByTable().set( "desc", " Who cares about lung cancer when you're high as a kite?" ).set( "name", "- Have a Puff" ), 
			new ByTable().set( "desc", " Because seven shots are all you need." ).set( "name", "- Revolver" ), 
			new ByTable().set( "desc", " A promotional poster for some rapper." ).set( "name", "- D-Day Promo" ), 
			new ByTable().set( "desc", " A poster advertising syndicate pistols as being 'classy as fuck'. It is covered in faded gang tags." ).set( "name", "- Syndicate Pistol" ), 
			new ByTable().set( "desc", " All the colors of the bloody murder rainbow." ).set( "name", "- Energy Swords" ), 
			new ByTable().set( "desc", " Looking at this poster makes you want to kill." ).set( "name", "- Red Rum" ), 
			new ByTable().set( "desc", " The latest portable computer from Comrade Computing, with a whole 64kB of ram!" ).set( "name", "- CC 64K Ad" ), 
			new ByTable().set( "desc", " Fight things for no reason, like a man!" ).set( "name", "- Punch Shit" ), 
			new ByTable().set( "desc", " The Griffin commands you to be the worst you can be. Will you?" ).set( "name", "- The Griffin" ), 
			new ByTable().set( "desc", " This lewd poster depicts a lizard preparing to mate." ).set( "name", "- Lizard" ), 
			new ByTable().set( "desc", " This poster commemorates the bravery of the rogue drone banned by CentComm." ).set( "name", "- Free Drone" ), 
			new ByTable().set( "desc", " Get a load, or give, of these all natural Xenos!" ).set( "name", "- Busty Backdoor Xeno Babes 6" )
		 });
		public static readonly ByTable corgi_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( 3, 3 ).set( 2, typeof(Ent_Item_Clothing_Suit_Hooded_IanCostume) ).set( 1, "corgi costume" ).applyCtor( typeof(StackRecipe) ) });
		public static dynamic create_mob_html = null;
		public static readonly ByTable create_object_forms = new ByTable(new object [] { typeof(Entity), typeof(Ent_Structure), typeof(Ent_Machinery), typeof(Ent_Effect), typeof(Ent_Item), typeof(Ent_Item_Clothing), typeof(Ent_Item_Stack), typeof(Ent_Item_Device), typeof(Ent_Item_Weapon), typeof(Ent_Item_Weapon_ReagentContainers), typeof(Ent_Item_Weapon_Gun) });
		public static dynamic create_object_html = null;
		public static dynamic create_turf_html = null;
		public static readonly ByTable crematoriums = new ByTable();
		public static readonly Crewmonitor crewmonitor = new Crewmonitor();
		public static readonly ByTable crit_allowed_modes = new ByTable(new object [] { "whisper", "changeling", "alientalk" });
		public static readonly ByTable custom_outfits = new ByTable();
		public static readonly dynamic data_core = null;
		public static readonly int days_early = 1;
		public static DBConnection dbcon = new DBConnection();
		public static ByTable dead_mob_list = new ByTable();
		public static ByTable deadmins = new ByTable();
		public static readonly ByTable deathsquadspawn = new ByTable();
		public static readonly int Debug = 0;
		public static int Debug2 = 0;
		public static readonly Chatroom default_ntrc_chatroom = new Chatroom();
		public static readonly ByTable defaults = new ByTable(new object [] { "No", "Yes" });
		public static ByTable deliverybeacons = new ByTable();
		public static ByTable deliverybeacontags = new ByTable();
		public static readonly ByTable department_radio_keys = new ByTable().set( ".ï", "changeling" ).set( "#ï", "changeling" ).set( ":ï", "changeling" ).set( ".é", "Supply" ).set( "#é", "Supply" ).set( ":é", "Supply" ).set( ".å", "Syndicate" ).set( "#å", "Syndicate" ).set( ":å", "Syndicate" ).set( ".ô", "alientalk" ).set( "#ô", "alientalk" ).set( ":ô", "alientalk" ).set( ".è", "binary" ).set( "#è", "binary" ).set( ":è", "binary" ).set( ".ö", "whisper" ).set( "#ö", "whisper" ).set( ":ö", "whisper" ).set( ".û", "Security" ).set( "#û", "Security" ).set( ":û", "Security" ).set( ".ó", "Engineering" ).set( "#ó", "Engineering" ).set( ":ó", "Engineering" ).set( ".ü", "Medical" ).set( "#ü", "Medical" ).set( ":ü", "Medical" ).set( ".ò", "Science" ).set( "#ò", "Science" ).set( ":ò", "Science" ).set( ".ñ", "Command" ).set( "#ñ", "Command" ).set( ":ñ", "Command" ).set( ".ð", "department" ).set( "#ð", "department" ).set( ":ð", "department" ).set( ".ø", "intercom" ).set( "#ø", "intercom" ).set( ":ø", "intercom" ).set( ".ä", "left hand" ).set( "#ä", "left hand" ).set( ":ä", "left hand" ).set( ".ê", "right hand" ).set( "#ê", "right hand" ).set( ":ê", "right hand" ).set( ".Y", "Centcom" ).set( "#Y", "Centcom" ).set( ":Y", "Centcom" ).set( ".G", "changeling" ).set( "#G", "changeling" ).set( ":G", "changeling" ).set( ".O", "AI Private" ).set( "#O", "AI Private" ).set( ":O", "AI Private" ).set( ".V", "Service" ).set( "#V", "Service" ).set( ":V", "Service" ).set( ".U", "Supply" ).set( "#U", "Supply" ).set( ":U", "Supply" ).set( ".T", "Syndicate" ).set( "#T", "Syndicate" ).set( ":T", "Syndicate" ).set( ".A", "alientalk" ).set( "#A", "alientalk" ).set( ":A", "alientalk" ).set( ".B", "binary" ).set( "#B", "binary" ).set( ":B", "binary" ).set( ".W", "whisper" ).set( "#W", "whisper" ).set( ":W", "whisper" ).set( ".S", "Security" ).set( "#S", "Security" ).set( ":S", "Security" ).set( ".E", "Engineering" ).set( "#E", "Engineering" ).set( ":E", "Engineering" ).set( ".M", "Medical" ).set( "#M", "Medical" ).set( ":M", "Medical" ).set( ".N", "Science" ).set( "#N", "Science" ).set( ":N", "Science" ).set( ".C", "Command" ).set( "#C", "Command" ).set( ":C", "Command" ).set( ".H", "department" ).set( "#H", "department" ).set( ":H", "department" ).set( ".I", "intercom" ).set( "#I", "intercom" ).set( ":I", "intercom" ).set( ".L", "left hand" ).set( "#L", "left hand" ).set( ":L", "left hand" ).set( ".R", "right hand" ).set( "#R", "right hand" ).set( ":R", "right hand" ).set( ".y", "Centcom" ).set( "#y", "Centcom" ).set( ":y", "Centcom" ).set( ".g", "changeling" ).set( "#g", "changeling" ).set( ":g", "changeling" ).set( ".o", "AI Private" ).set( "#o", "AI Private" ).set( ":o", "AI Private" ).set( ".v", "Service" ).set( "#v", "Service" ).set( ":v", "Service" ).set( ".u", "Supply" ).set( "#u", "Supply" ).set( ":u", "Supply" ).set( ".t", "Syndicate" ).set( "#t", "Syndicate" ).set( ":t", "Syndicate" ).set( ".a", "alientalk" ).set( "#a", "alientalk" ).set( ":a", "alientalk" ).set( ".b", "binary" ).set( "#b", "binary" ).set( ":b", "binary" ).set( ".w", "whisper" ).set( "#w", "whisper" ).set( ":w", "whisper" ).set( ".s", "Security" ).set( "#s", "Security" ).set( ":s", "Security" ).set( ".e", "Engineering" ).set( "#e", "Engineering" ).set( ":e", "Engineering" ).set( ".m", "Medical" ).set( "#m", "Medical" ).set( ":m", "Medical" ).set( ".n", "Science" ).set( "#n", "Science" ).set( ":n", "Science" ).set( ".c", "Command" ).set( "#c", "Command" ).set( ":c", "Command" ).set( ".h", "department" ).set( "#h", "department" ).set( ":h", "department" ).set( ".i", "intercom" ).set( "#i", "intercom" ).set( ":i", "intercom" ).set( ".l", "left hand" ).set( "#l", "left hand" ).set( ":l", "left hand" ).set( ".r", "right hand" ).set( "#r", "right hand" ).set( ":r", "right hand" );
		public static ByTable department_security_spawns = new ByTable();
		public static readonly ByTable diagonals = new ByTable(new object [] { GlobalVars.NORTHEAST, GlobalVars.NORTHWEST, GlobalVars.SOUTHEAST, GlobalVars.SOUTHWEST });
		public static readonly ByTable diamond_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_MineralDoor_Transparent_Diamond) ).set( 1, "diamond door" ).applyCtor( typeof(StackRecipe) ), new StackRecipe( "diamond tile", typeof(Ent_Item_Stack_Tile_Mineral_Diamond), 1, 4, 20 ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Diamond_Captain) ).set( 1, "Captain Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Diamond_Ai1) ).set( 1, "AI Hologram Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Diamond_Ai2) ).set( 1, "AI Core Statue" ).applyCtor( typeof(StackRecipe) ) });
		public static readonly dynamic diary = null;
		public static readonly dynamic diaryofmeanpeople = null;
		public static readonly ByTable dictionary_symptoms = new ByTable();
		public static readonly ByTable direction_table = new ByTable();
		public static ByTable directory = new ByTable();
		public static readonly int DISCONNECTED = 0;
		public static readonly ByTable diseases = Misc13.types( typeof(Disease) ) - typeof(Disease);
		public static readonly ByTable disposalpipeID2State = new ByTable(new object [] { "pipe-s", "pipe-c", "pipe-j1", "pipe-j2", "pipe-y", "pipe-t", "disposal", "outlet", "intake", "pipe-j1s", "pipe-j2s" });
		public static dynamic dooc_allowed = 1;
		public static ByTable doppler_arrays = new ByTable();
		public static readonly int DOWN = 32;
		public static readonly int duration = 13;
		public static readonly ByTable ears_list = new ByTable();
		public static readonly int EAST = 4;
		public static readonly int EFFECTS_LAYER = 5000;
		public static int emergency_access = 0;
		public static ByTable emergencyresponseteamspawn = new ByTable();
		public static ByTable emojis = null;
		public static readonly int ENG_FREQ = 1357;
		public static readonly ByTable engineering_positions = new ByTable(new object [] { "Chief Engineer", "Station Engineer", "Atmospheric Technician" });
		public static readonly int ENGSEC = 1;
		public static dynamic enter_allowed = 1;
		public static readonly int EYE_PERSPECTIVE = 1;
		public static readonly ByTable facial_hair_styles_female_list = new ByTable();
		public static readonly ByTable facial_hair_styles_list = new ByTable();
		public static readonly ByTable facial_hair_styles_male_list = new ByTable();
		public static int failed_db_connections = 0;
		public static Controller_Failsafe Failsafe = null;
		public static readonly int FALSE = 0;
		public static readonly string FEMALE = "female";
		public static readonly ByTable female_clothing_icons = new ByTable();
		public static double fileaccess_timer = 0;
		public static readonly dynamic fire_overlay = new ByTable().set( "icon_state", "fire" ).set( "icon", "icons/effects/fire.dmi" ).applyCtor( typeof(Image) );
		public static readonly dynamic first_names_female = GlobalFuncs.file2list( "config/names/first_female.txt" );
		public static readonly dynamic first_names_male = GlobalFuncs.file2list( "config/names/first_male.txt" );
		public static readonly int FLOAT_LAYER = -1;
		public static int floorIsLava = 0;
		public static readonly int FLY_LAYER = 5;
		public static readonly ByTable forbidden_varedit_object_types = new ByTable(new object [] { typeof(Admins), typeof(Ent_Machinery_BlackboxRecorder), typeof(FeedbackVariable), typeof(AdminRank) });
		public static readonly int FREQ_LISTENING = 1;
		public static readonly ByTable freqtospan = new ByTable().set( "1337", "centcomradio" ).set( "1213", "syndradio" ).set( "1447", "aiprivradio" ).set( "1353", "comradio" ).set( "1359", "secradio" ).set( "1349", "servradio" ).set( "1347", "suppradio" ).set( "1357", "engradio" ).set( "1355", "medradio" ).set( "1351", "sciradio" );
		public static readonly ByTable frills_list = new ByTable();
		public static ByTable g_fancy_list_of_types = null;
		public static ByTable gang_colors_pool = new ByTable(new object [] { "red", "orange", "yellow", "green", "blue", "purple" });
		public static ByTable gang_name_pool = new ByTable(new object [] { "Clandestine", "Prima", "Zero-G", "Max", "Blasto", "Waffle", "North", "Omni", "Newton", "Cyber", "Donk", "Gene", "Gib", "Tunnel", "Diablo", "Psyke", "Osiron", "Sirius", "Sleeping Carp" });
		public static dynamic gaussian_next = null;
		public static ByTable ghost_darkness_images = new ByTable();
		public static readonly ByTable ghost_forms = new ByTable(new object [] { "ghost", "ghostking", "ghostian2", "skeleghost", "ghost_red", "ghost_black", "ghost_blue", "ghost_yellow", "ghost_green", "ghost_pink", "ghost_cyan", "ghost_dblue", "ghost_dred", "ghost_dgreen", "ghost_dcyan", "ghost_grey", "ghost_dyellow", "ghost_dpink", "ghost_purpleswirl", "ghost_funkypurp", "ghost_pinksherbert", "ghost_blazeit", "ghost_mellow", "ghost_rainbow", "ghost_camo", "ghost_fire" });
		public static int gid = 1;
		public static int gl_uid = 1;
		public static readonly GlobalHud global_hud = new GlobalHud();
		public static readonly ByTable global_map = null;
		public static readonly ByTable global_mutations = new ByTable();
		public static int global_uid = 0;
		public static readonly ByTable globalBlankCanvases = new ByTable( 4 );
		public static readonly ByTable GlobalPool = new ByTable();
		public static readonly ByTable gold_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_MineralDoor_Gold) ).set( 1, "golden door" ).applyCtor( typeof(StackRecipe) ), new StackRecipe( "gold tile", typeof(Ent_Item_Stack_Tile_Mineral_Gold), 1, 4, 20 ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Gold_Hos) ).set( 1, "HoS Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Gold_Hop) ).set( 1, "HoP Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Gold_Ce) ).set( 1, "CE Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Gold_Rd) ).set( 1, "RD Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Gold_Cmo) ).set( 1, "CMO Statue" ).applyCtor( typeof(StackRecipe) ) });
		public static ByTable good_mutations = new ByTable();
		public static readonly ByTable GPS_list = new ByTable();
		public static readonly ByTable gravity_generators = new ByTable();
		public static dynamic guests_allowed = 1;
		public static readonly ByTable hair_styles_female_list = new ByTable();
		public static readonly ByTable hair_styles_list = new ByTable();
		public static readonly ByTable hair_styles_male_list = new ByTable();
		public static readonly ByTable hex_characters = new ByTable(new object [] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "a", "b", "c", "d", "e", "f" });
		public static readonly ByTable hit_appends = new ByTable(new object [] { "-OOF", "-ACK", "-UGH", "-HRNK", "-HURGH", "-GLORF" });
		public static ByTable hivemind_bank = new ByTable();
		public static ByTable holdingfacility = new ByTable();
		public static readonly int HOLOPAD_MODE = 4;
		public static readonly ByTable horns_list = new ByTable();
		public static dynamic host = null;
		public static readonly dynamic href_logfile = null;
		public static readonly ByTable hrefs = new ByTable().set( "Spawn Air Canister", "hsbspawn&path=" + typeof(Ent_Machinery_PortableAtmospherics_Canister_Air) ).set( "Spawn O2 Canister", "hsbspawn&path=" + typeof(Ent_Machinery_PortableAtmospherics_Canister_Oxygen) ).set( 31, "Canisters" ).set( "Spawn Medbot", "hsbspawn&path=" + typeof(Ent_Machinery_Bot_Medbot) ).set( "Spawn Floorbot", "hsbspawn&path=" + typeof(Ent_Machinery_Bot_Floorbot) ).set( "Spawn Cleanbot", "hsbspawn&path=" + typeof(Ent_Machinery_Bot_Cleanbot) ).set( 27, "Bots" ).set( "Spawn Water Tank", "hsbspawn&path=" + typeof(Ent_Structure_ReagentDispensers_Watertank) ).set( "Spawn Welding Fuel Tank", "hsbspawn&path=" + typeof(Ent_Structure_ReagentDispensers_Fueltank) ).set( "Spawn Air Scrubber", "hsbscrubber" ).set( 23, "Miscellaneous" ).set( "Spawn Airlock", "hsbairlock" ).set( "Spawn RCD Ammo", "hsb_safespawn&path=" + typeof(Ent_Item_Weapon_RcdAmmo) ).set( "Spawn Rapid Construction Device", "hsbrcd" ).set( "Spawn Inf. Capacity Power Cell", "hsbspawn&path=" + typeof(Ent_Item_Weapon_StockParts_Cell_Infinite) ).set( "Spawn Hyper Capacity Power Cell", "hsbspawn&path=" + typeof(Ent_Item_Weapon_StockParts_Cell_Hyper) ).set( "Spawn Full Cable Coil", "hsbspawn&path=" + typeof(Ent_Item_Stack_CableCoil) ).set( "Spawn 50 Glass", "hsbglass" ).set( "Spawn 50 Reinforced Glass", "hsbrglass" ).set( "Spawn 50 Plasteel", "hsbplasteel" ).set( "Spawn 50 Metal", "hsbmetal" ).set( "Spawn 50 Wood", "hsbwood" ).set( 11, "Building Supplies" ).set( "Spawn All-Access ID", "hsbaaid" ).set( "Spawn Medical Kit", "hsbspawn&path=" + typeof(Ent_Item_Weapon_Storage_Firstaid_Regular) ).set( "Spawn Light Replacer", "hsbspawn&path=" + typeof(Ent_Item_Device_Lightreplacer) ).set( "Spawn Toolbox", "hsbspawn&path=" + typeof(Ent_Item_Weapon_Storage_Toolbox_Mechanical) ).set( "Spawn Flashlight", "hsbspawn&path=" + typeof(Ent_Item_Device_Flashlight) ).set( 5, "Standard Tools" ).set( "Spawn Emergency Air Tank", "hsbspawn&path=" + typeof(Ent_Item_Weapon_Tank_Internals_EmergencyOxygen_Double) ).set( "Spawn Gas Mask", "hsbspawn&path=" + typeof(Ent_Item_Clothing_Mask_Gas) ).set( "Suit Up (Space Travel Gear)", "hsbsuit" ).set( 1, "Space Gear" );
		public static int hsboxspawn = 1;
		public static readonly ByTable html_interfaces = new ByTable();
		public static readonly ByTable huds = new ByTable().set( 10, new AtomHud_Antag() ).set( 9, new AtomHud_Antag() ).set( 8, new AtomHud_Antag() ).set( 7, new AtomHud_Antag() ).set( 6, new AtomHud_Antag() ).set( 5, new AtomHud_Data_Diagnostic() ).set( 4, new AtomHud_Data_Human_Medical_Advanced() ).set( 3, new AtomHud_Data_Human_Medical_Basic() ).set( 2, new AtomHud_Data_Human_Security_Advanced() ).set( 1, new AtomHud_Data_Human_Security_Basic() );
		public static readonly ByTable IClog = new ByTable();
		public static readonly int ICON_SIZE = 4;
		public static readonly ByTable icons_to_ignore_at_floor_init = new ByTable(new object [] { "damaged1", "damaged2", "damaged3", "damaged4", "damaged5", "panelscorched", "floorscorched1", "floorscorched2", "platingdmg1", "platingdmg2", "platingdmg3", "plating", "light_on", "light_on_flicker1", "light_on_flicker2", "light_on_clicker3", "light_on_clicker4", "light_on_clicker5", "light_broken", "light_on_broken", "light_off", "wall_thermite", "grass", "sand", "asteroid", "asteroid_dug", "asteroid0", "asteroid1", "asteroid2", "asteroid3", "asteroid4", "asteroid5", "asteroid6", "asteroid7", "asteroid8", "asteroid9", "asteroid10", "asteroid11", "asteroid12", "oldburning", "light-on-r", "light-on-y", "light-on-g", "light-on-b", "wood", "wood-broken", "carpetcorner", "carpetside", "carpet", "ironsand1", "ironsand2", "ironsand3", "ironsand4", "ironsand5", "ironsand6", "ironsand7", "ironsand8", "ironsand9", "ironsand10", "ironsand11", "ironsand12", "ironsand13", "ironsand14", "ironsand15" });
		public static readonly ByTable iconsetids = new ByTable();
		public static readonly int INGEST = 2;
		public static int intercom_range_display_status = 0;
		public static readonly ByTable jobban_keylist = new ByTable( 0 );
		public static readonly dynamic join_motd = null;
		public static ByTable joined_player_list = new ByTable();
		public static readonly string js_byjax = "\n\nfunction replaceContent() {\n	var args = Array.prototype.slice.call(arguments);\n	var id = args[0];\n	var content = args[1];\n	var callback  = null;\n	if(args[2]){\n		callback = args[2];\n		if(args[3]){\n			args = args.slice(3);\n		}\n	}\n	var parent = document.getElementById(id);\n	if(typeof(parent)!=='undefined' && parent!=null){\n		parent.innerHTML = content?content:'';\n	}\n	if(callback && window[callback]){\n		window[callback].apply(null,args);\n	}\n}\n";
		public static readonly string js_dropdowns = "\nfunction dropdowns() {\n    var divs = document.getElementsByTagName('div');\n    var headers = new Array();\n    var links = new Array();\n    for(var i=0;i<divs.length;i++){\n        if(divs[i].className=='header') {\n            divs[i].className='header closed';\n            divs[i].innerHTML = divs[i].innerHTML+' +';\n            headers.push(divs[i]);\n        }\n        if(divs[i].className=='links') {\n            divs[i].className='links hidden';\n            links.push(divs[i]);\n        }\n    }\n    for(var i=0;i<headers.length;i++){\n        if(typeof(links[i])!== 'undefined' && links[i]!=null) {\n            headers[i].onclick = (function(elem) {\n                return function() {\n                    if(elem.className.search('visible')>=0) {\n                        elem.className = elem.className.replace('visible','hidden');\n                        this.className = this.className.replace('open','closed');\n                        this.innerHTML = this.innerHTML.replace('-','+');\n                    }\n                    else {\n                        elem.className = elem.className.replace('hidden','visible');\n                        this.className = this.className.replace('closed','open');\n                        this.innerHTML = this.innerHTML.replace('+','-');\n                    }\n                return false;\n                }\n            })(links[i]);\n        }\n    }\n}\n";
		public static readonly ByTable json_escape = new ByTable(new object [] { "\\", "\"", "'", "\n" });
		public static ByTable landmarks_list = new ByTable();
		public static readonly dynamic last_names = GlobalFuncs.file2list( "config/names/last.txt" );
		public static readonly ByTable lastsignalers = new ByTable();
		public static ByTable latejoin = new ByTable();
		public static readonly ByTable lawchanges = new ByTable();
		public static readonly ByTable legitposters = new ByTable(new object [] { 
			new ByTable().set( "desc", " A poster glorifying the station's security force." ).set( "name", "- Here For Your Safety" ), 
			new ByTable().set( "desc", " A poster depicting the Nanotrasen logo." ).set( "name", "- Nanotrasen Logo" ), 
			new ByTable().set( "desc", " A poster warning of the dangers of poor hygiene." ).set( "name", "- Cleanliness" ), 
			new ByTable().set( "desc", " A poster encouraging you to help fellow crewmembers." ).set( "name", "- Help Others" ), 
			new ByTable().set( "desc", " A poster glorifying the engineering team." ).set( "name", "- Build" ), 
			new ByTable().set( "desc", " A poster blessing this area." ).set( "name", "- Bless This Spess" ), 
			new ByTable().set( "desc", " A poster depicting an atom." ).set( "name", "- Science" ), 
			new ByTable().set( "desc", " Arf arf. Yap." ).set( "name", "- Ian" ), 
			new ByTable().set( "desc", " A poster instructing the viewer to obey authority." ).set( "name", "- Obey" ), 
			new ByTable().set( "desc", " A poster instructing the viewer to walk instead of running." ).set( "name", "- Walk" ), 
			new ByTable().set( "desc", " A poster instructing cyborgs to state their laws." ).set( "name", "- State Laws" ), 
			new ByTable().set( "desc", " Ian is love, Ian is life." ).set( "name", "- Love Ian" ), 
			new ByTable().set( "desc", " A poster advertising the television show Space Cops." ).set( "name", "- Space Cops." ), 
			new ByTable().set( "desc", " This thing is all in Japanese." ).set( "name", "- Ue No." ), 
			new ByTable().set( "desc", " LEGS: Leadership, Experience, Genius, Subordination." ).set( "name", "- Get Your LEGS" ), 
			new ByTable().set( "desc", " A poster instructing the viewer not to ask about things they aren't meant to know." ).set( "name", "- Do Not Question" ), 
			new ByTable().set( "desc", " A poster encouraging you to work for your future." ).set( "name", "- Work For A Future" ), 
			new ByTable().set( "desc", " A poster reprint of some cheap pop art." ).set( "name", "- Soft Cap Pop Art" ), 
			new ByTable().set( "desc", " A poster instructing the viewer to wear internals in the rare environments where there is no oxygen or the air has been rendered toxic." ).set( "name", "- Safety: Internals" ), 
			new ByTable().set( "desc", " A poster instructing the viewer to wear eye protection when dealing with chemicals, smoke, or bright lights." ).set( "name", "- Safety: Eye Protection" ), 
			new ByTable().set( "desc", " A poster instructing the viewer to report suspicious activity to the security force." ).set( "name", "- Safety: Report" ), 
			new ByTable().set( "desc", " A poster encouraging the swift reporting of crime or seditious behavior to station security." ).set( "name", "- Report Crimes" ), 
			new ByTable().set( "desc", " A poster displaying an Ion Rifle." ).set( "name", "- Ion Rifle" ), 
			new ByTable().set( "desc", " Foam Force, it's Foam or be Foamed!" ).set( "name", "- Foam Force Ad" ), 
			new ByTable().set( "desc", " Cohiba Robusto, the classy cigar." ).set( "name", "- Cohiba Robusto Ad" ), 
			new ByTable().set( "desc", " A reprint of a poster from 2505, commemorating the 50th Aniversery of Nanoposters Manufacturing, a subsidary of Nanotrasen." ).set( "name", "- 50th Anniversary Vintage Reprint" ), 
			new ByTable().set( "desc", " Simple, yet awe-inspiring." ).set( "name", "- Fruit Bowl" ), 
			new ByTable().set( "desc", " A poster advertising the latest PDA from Nanotrasen suppliers." ).set( "name", "- PDA Ad" ), 
			new ByTable().set( "desc", " Enlist in the Nanotrasen Deathsquadron reserves today!" ).set( "name", "- Enlist" ), 
			new ByTable().set( "desc", " A poster advertising Nanomichi brand audio cassettes." ).set( "name", "- Nanomichi Ad" ), 
			new ByTable().set( "desc", " A poster boasting about the superiority of 12 gauge shotgun shells." ).set( "name", "- 12 Gauge" ), 
			new ByTable().set( "desc", " I told you to shake it, no stirring." ).set( "name", "- High-Class Martini" ), 
			new ByTable().set( "desc", " The Owl would do his best to protect the station. Will you?" ).set( "name", "- The Owl" ), 
			new ByTable().set( "desc", " This poster reminds the crew that Eroticism, Rape and Pornography are banned on Nanotrasen stations." ).set( "name", "- No ERP" ), 
			new ByTable().set( "desc", " This informational poster teaches the viewer what carbon dioxide is." ).set( "name", "- Carbon Dioxide" )
		 });
		public static readonly dynamic list_symptoms = Misc13.types( typeof(Symptom) ) - typeof(Symptom);
		public static ByTable living_mob_list = new ByTable();
		public static readonly dynamic lizard_names_female = GlobalFuncs.file2list( "config/names/lizard_female.txt" );
		public static readonly dynamic lizard_names_male = GlobalFuncs.file2list( "config/names/lizard_male.txt" );
		public static ByTable machines = new ByTable();
		public static readonly string MALE = "male";
		public static readonly ByTable map_transition_config = new ByTable().set( "Empty Area 2", 2 ).set( "Empty Area 1", 2 ).set( "Mining Asteroid", 2 ).set( "Derelicted Station", 2 ).set( "Abandoned Satellite", 2 ).set( "CentComm", 1 ).set( "Main Station", 2 );
		public static readonly DmmSuite maploader = new DmmSuite();
		public static Controller_GameController master_controller = new Controller_GameController();
		public static dynamic master_mode = "traitor";
		public static readonly int MAX_ACTIVE_TIME = 400;
		public static readonly int MAX_CHICKENS = 50;
		public static int MAX_EX_DEVESTATION_RANGE = 3;
		public static int MAX_EX_FLAME_RANGE = 14;
		public static int MAX_EX_FLASH_RANGE = 14;
		public static int MAX_EX_HEAVY_RANGE = 7;
		public static int MAX_EX_LIGHT_RANGE = 14;
		public static readonly int max_health = 100;
		public static readonly int MAX_ICON_DIMENSION = 1024;
		public static readonly int MAX_IMPREGNATION_TIME = 150;
		public static readonly int max_secret_rooms = 6;
		public static readonly int max_signs = 4;
		public static ByTable mechas_list = new ByTable();
		public static readonly int MED_FREQ = 1355;
		public static readonly ByTable medical_positions = new ByTable(new object [] { "Chief Medical Officer", "Medical Doctor", "Geneticist", "Virologist", "Chemist" });
		public static readonly int MEDSCI = 2;
		public static int message_delay = 0;
		public static ByTable message_servers = new ByTable();
		public static readonly ByTable metal_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 2, typeof(Ent_Structure_Bed_Stool) ).set( 1, "stool" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 2, typeof(Ent_Structure_Bed_Chair) ).set( 1, "chair" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Bed_Chair_Office_Dark) ).set( 1, "swivel chair" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 2 ).set( 2, typeof(Ent_Structure_Bed_Chair_Comfy_Beige) ).set( 1, "comfy chair" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 2 ).set( 2, typeof(Ent_Structure_Bed) ).set( 1, "bed" ).applyCtor( typeof(StackRecipe) ), null, new StackRecipe( "rack parts", typeof(Ent_Item_Weapon_RackParts) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 15 ).set( 3, 2 ).set( 2, typeof(Ent_Structure_Closet) ).set( 1, "closet" ).applyCtor( typeof(StackRecipe) ), null, new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 15 ).set( 3, 10 ).set( 2, typeof(Ent_Machinery_PortableAtmospherics_Canister) ).set( 1, "canister" ).applyCtor( typeof(StackRecipe) ), null, new StackRecipe( "floor tile", typeof(Ent_Item_Stack_Tile_Plasteel), 1, 4, 20 ), new StackRecipe( "metal rod", typeof(Ent_Item_Stack_Rods), 1, 2, 60 ), null, new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 25 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Computerframe) ).set( 1, "computer frame" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 50 ).set( 3, 2 ).set( 2, typeof(Ent_Structure_Girder) ).set( 1, "wall girders" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 50 ).set( 3, 4 ).set( 2, typeof(Ent_Structure_DoorAssembly) ).set( 1, "airlock assembly" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 50 ).set( 3, 3 ).set( 2, typeof(Ent_Structure_FirelockFrame) ).set( 1, "firelock frame" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 25 ).set( 3, 5 ).set( 2, typeof(Ent_Machinery_ConstructableFrame_MachineFrame) ).set( 1, "machine frame" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 25 ).set( 3, 5 ).set( 2, typeof(Ent_Machinery_PortaTurretConstruct) ).set( 1, "turret frame" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 25 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_KitchenspikeFrame) ).set( 1, "meatspike frame" ).applyCtor( typeof(StackRecipe) ), null, new StackRecipe( "grenade casing", typeof(Ent_Item_Weapon_Grenade_ChemGrenade) ), new StackRecipe( "light fixture frame", typeof(Ent_Item_Wallframe_LightFixture), 2 ), new StackRecipe( "small light fixture frame", typeof(Ent_Item_Wallframe_LightFixture_Small), 1 ), null, new StackRecipe( "apc frame", typeof(Ent_Item_Wallframe_Apc), 2 ), new StackRecipe( "air alarm frame", typeof(Ent_Item_Wallframe_Alarm), 2 ), new StackRecipe( "fire alarm frame", typeof(Ent_Item_Wallframe_Firealarm), 2 ), new StackRecipe( "button frame", typeof(Ent_Item_Wallframe_Button), 1 ), null, new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 20 ).set( 2, typeof(Ent_Structure_MineralDoor_Iron) ).set( 1, "iron door" ).applyCtor( typeof(StackRecipe) ) });
		public static readonly int meteordelay = 2000;
		public static readonly ByTable meteors_catastrophic = new ByTable().set( typeof(Ent_Effect_Meteor_Tunguska), 1 ).set( typeof(Ent_Effect_Meteor_Irradiated), 10 ).set( typeof(Ent_Effect_Meteor_Flaming), 10 ).set( typeof(Ent_Effect_Meteor_Big), 75 ).set( typeof(Ent_Effect_Meteor_Medium), 5 );
		public static readonly ByTable meteors_normal = new ByTable().set( typeof(Ent_Effect_Meteor_Irradiated), 3 ).set( typeof(Ent_Effect_Meteor_Flaming), 1 ).set( typeof(Ent_Effect_Meteor_Big), 3 ).set( typeof(Ent_Effect_Meteor_Medium), 8 ).set( typeof(Ent_Effect_Meteor_Dust), 3 );
		public static readonly ByTable meteors_threatening = new ByTable().set( typeof(Ent_Effect_Meteor_Irradiated), 3 ).set( typeof(Ent_Effect_Meteor_Flaming), 3 ).set( typeof(Ent_Effect_Meteor_Big), 8 ).set( typeof(Ent_Effect_Meteor_Medium), 4 );
		public static readonly ByTable meteorsB = new ByTable().set( typeof(Ent_Effect_Meteor_Meaty_Xeno), 1 ).set( typeof(Ent_Effect_Meteor_Meaty), 5 );
		public static readonly ByTable meteorsC = new ByTable(new object [] { typeof(Ent_Effect_Meteor_Dust) });
		public static readonly ByTable meteorsSPOOKY = new ByTable(new object [] { typeof(Ent_Effect_Meteor_Pumpkin) });
		public static readonly dynamic mime_names = GlobalFuncs.file2list( "config/names/mime.txt" );
		public static readonly int MIN_ACTIVE_TIME = 200;
		public static readonly int MIN_IMPREGNATION_TIME = 100;
		public static readonly int MOB_LAYER = 4;
		public static ByTable mob_list = new ByTable();
		public static readonly int MOB_PERSPECTIVE = 0;
		public static readonly Moduletypes mods = new Moduletypes();
		public static ByTable modules = new ByTable().set( "/obj/machinery/power/apc", "card_reader,power_control,id_auth,cell_power,cell_charge" );
		public static readonly ByTable monkey_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( 3, 1 ).set( 2, typeof(Ent_Item_Clothing_Mask_Gas_Monkeymask) ).set( 1, "monkey mask" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( 3, 2 ).set( 2, typeof(Ent_Item_Clothing_Suit_Monkeysuit) ).set( 1, "monkey suit" ).applyCtor( typeof(StackRecipe) ) });
		public static ByTable monkeystart = new ByTable();
		public static int mulebot_count = 0;
		public static ByTable multiverse = new ByTable();
		public static readonly ByTable mutations_list = new ByTable();
		public static ByTable navbeacons = new ByTable();
		public static ByTable newplayer_start = new ByTable();
		public static readonly Newscaster_FeedNetwork news_network = new Newscaster_FeedNetwork();
		public static int next_mob_id = 0;
		public static int nextid = 1;
		public static dynamic nextmap = null;
		public static readonly dynamic ninja_names = GlobalFuncs.file2list( "config/names/ninjaname.txt" );
		public static readonly dynamic ninja_titles = GlobalFuncs.file2list( "config/names/ninjatitle.txt" );
		public static readonly int NO_SLIP_WHEN_WALKING = 1;
		public static readonly ByTable non_fakeattack_weapons = new ByTable(new object [] { typeof(Ent_Item_Weapon_Gun_Projectile), typeof(Ent_Item_AmmoBox_A357), typeof(Ent_Item_Weapon_Gun_Energy_KineticAccelerator_Crossbow), typeof(Ent_Item_Weapon_Melee_Energy_Sword_Saber), typeof(Ent_Item_Weapon_Storage_Box_Syndicate), typeof(Ent_Item_Weapon_Storage_Box_Emps), typeof(Ent_Item_Weapon_Cartridge_Syndicate), typeof(Ent_Item_Clothing_Under_Chameleon), typeof(Ent_Item_Clothing_Shoes_Sneakers_Syndigaloshes), typeof(Ent_Item_Weapon_Card_Id_Syndicate), typeof(Ent_Item_Clothing_Mask_Gas_Voice), typeof(Ent_Item_Clothing_Glasses_Thermal), typeof(Ent_Item_Device_Chameleon), typeof(Ent_Item_Weapon_Card_Emag), typeof(Ent_Item_Weapon_Storage_Toolbox_Syndicate), typeof(Ent_Item_Weapon_AiModule), typeof(Ent_Item_Device_Radio_Headset_Syndicate), typeof(Ent_Item_Weapon_C4), typeof(Ent_Item_Device_Powersink), typeof(Ent_Item_Weapon_Storage_Box_SyndieKit), typeof(Ent_Item_Toy_Syndicateballoon), typeof(Ent_Item_Weapon_Gun_Energy_Laser_Captain), typeof(Ent_Item_Weapon_HandTele), typeof(Ent_Item_Weapon_Rcd), typeof(Ent_Item_Weapon_Tank_Jetpack), typeof(Ent_Item_Clothing_Under_Rank_Captain), typeof(Ent_Item_Device_Aicard), typeof(Ent_Item_Clothing_Shoes_Magboots), typeof(Ent_Item_Areaeditor_Blueprints), typeof(Ent_Item_Weapon_Disk_Nuclear), typeof(Ent_Item_Clothing_Suit_Space_Nasavoid), typeof(Ent_Item_Weapon_Tank) });
		public static readonly dynamic non_revealed_runes = Misc13.types( typeof(Ent_Effect_Rune) ) - typeof(Ent_Effect_Rune_Malformed) - typeof(Ent_Effect_Rune);
		public static readonly ByTable nonhuman_positions = new ByTable(new object [] { "AI", "Cyborg", "pAI" });
		public static string normal_ooc_colour = "#002eb8";
		public static readonly int NORTH = 1;
		public static readonly int NORTHEAST = 5;
		public static readonly int NORTHWEST = 9;
		public static ByTable not_good_mutations = new ByTable();
		public static ByTable nuke_list = new ByTable();
		public static readonly int num_power_levels = 6;
		public static readonly int OBJ_LAYER = 3;
		public static dynamic ooc_allowed = 1;
		public static readonly ByTable OOClog = new ByTable();
		public static readonly int OPEN_DURATION = 6;
		public static readonly int OPERATING = 2;
		public static readonly int PARTICLE_STRENGTH_WIRE = 2;
		public static readonly int PARTICLE_TOGGLE_WIRE = 1;
		public static readonly int PATCH = 4;
		public static ByTable PDAs = new ByTable();
		public static readonly ByTable pipe_types = new ByTable(new object [] { typeof(Ent_Machinery_Atmospherics_Pipe_Simple), typeof(Ent_Machinery_Atmospherics_Pipe_Manifold), typeof(Ent_Machinery_Atmospherics_Pipe_Manifold4w), typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Simple), typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold), typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold4w), typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Junction), typeof(Ent_Machinery_Atmospherics_Components_Unary_PortablesConnector), typeof(Ent_Machinery_Atmospherics_Components_Unary_VentPump), typeof(Ent_Machinery_Atmospherics_Components_Unary_VentScrubber), typeof(Ent_Machinery_Atmospherics_Components_Unary_HeatExchanger), typeof(Ent_Machinery_Atmospherics_Components_Binary_Pump), typeof(Ent_Machinery_Atmospherics_Components_Binary_PassiveGate), typeof(Ent_Machinery_Atmospherics_Components_Binary_VolumePump), typeof(Ent_Machinery_Atmospherics_Components_Binary_Valve), typeof(Ent_Machinery_Atmospherics_Components_Binary_Valve_Digital), typeof(Ent_Machinery_Atmospherics_Components_Trinary_Filter), typeof(Ent_Machinery_Atmospherics_Components_Trinary_Mixer) });
		public static readonly ByTable pipeID2State = new ByTable().set( "" + typeof(Ent_Machinery_Atmospherics_Components_Trinary_Mixer), "mixer" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Trinary_Filter), "filter" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Binary_Valve_Digital), "dvalve" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Binary_Valve), "mvalve" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Binary_VolumePump), "volumepump" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Binary_PassiveGate), "passivegate" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Binary_Pump), "pump" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Unary_HeatExchanger), "heunary" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Unary_VentScrubber), "scrubber" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Unary_VentPump), "uvent" ).set( "" + typeof(Ent_Machinery_Atmospherics_Components_Unary_PortablesConnector), "connector" ).set( "" + typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Junction), "junction" ).set( "" + typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold4w), "he_manifold4w" ).set( "" + typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold), "he_manifold" ).set( "" + typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Simple), "he" ).set( "" + typeof(Ent_Machinery_Atmospherics_Pipe_Manifold4w), "manifold4w" ).set( "" + typeof(Ent_Machinery_Atmospherics_Pipe_Manifold), "manifold" ).set( "" + typeof(Ent_Machinery_Atmospherics_Pipe_Simple), "simple" );
		public static readonly ByTable pipeimages = new ByTable();
		public static int pipenetwarnings = 10;
		public static readonly int PIZZA_WIRE_DISARM = 1;
		public static readonly ByTable plasma_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_MineralDoor_Transparent_Plasma) ).set( 1, "plasma door" ).applyCtor( typeof(StackRecipe) ), new StackRecipe( "plasma tile", typeof(Ent_Item_Stack_Tile_Mineral_Plasma), 1, 4, 20 ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Plasma_Scientist) ).set( 1, "Scientist Statue" ).applyCtor( typeof(StackRecipe) ) });
		public static readonly dynamic plasmaman_on_fire = new ByTable().set( "icon_state", "plasmaman" ).set( "icon", "icons/mob/OnFire.dmi" ).applyCtor( typeof(Image) );
		public static readonly ByTable plasteel_recipes = new ByTable(new object [] { new ByTable().set( "one_per_turf", 1 ).set( "time", 50 ).set( 3, 4 ).set( 2, typeof(Ent_Structure_AIcore) ).set( 1, "AI core" ).applyCtor( typeof(StackRecipe) ) });
		public static ByTable player_list = new ByTable();
		public static readonly string PLURAL = "plural";
		public static ByTable pointers = new ByTable();
		public static ByTable portals = new ByTable();
		public static int posibrain_notif_cooldown = 0;
		public static ByTable possible_changeling_IDs = new ByTable(new object [] { "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa", "Lambda", "Mu", "Nu", "Xi", "Omicron", "Pi", "Rho", "Sigma", "Tau", "Upsilon", "Phi", "Chi", "Psi", "Omega" });
		public static readonly ByTable possible_items = new ByTable();
		public static readonly ByTable possible_items_special = new ByTable();
		public static ByTable possible_uplinker_IDs = new ByTable(new object [] { "Alfa", "Bravo", "Charlie", "Delta", "Echo", "Foxtrot", "Zero", "Niner" });
		public static readonly ByTable possibleShadowlingNames = new ByTable(new object [] { "U'ruan", "Y`shej", "Nex", "Hel-uae", "Noaey'gief", "Mii`mahza", "Amerziox", "Gyrg-mylin", "Kanet'pruunance", "Vigistaezian" });
		public static ByTable possiblethemes = new ByTable(new object [] { "organharvest", "cult", "wizden", "cavein", "xenoden", "hitech", "speakeasy", "plantlab" });
		public static readonly int POWER_DOWN = 2;
		public static readonly int POWER_IDLE = 0;
		public static readonly int POWER_UP = 1;
		public static ByTable powernets = new ByTable();
		public static readonly ByTable preferences_datums = new ByTable();
		public static ByTable prisonsecuritywarp = new ByTable();
		public static ByTable prisonwarp = new ByTable();
		public static readonly ByTable prisonwarped = new ByTable();
		public static Subsystem_Procqueue procqueue = null;
		public static readonly dynamic protected_config = null;
		public static readonly ByTable protected_objects = new ByTable(new object [] { typeof(Ent_Structure_Table), typeof(Ent_Structure_Cable), typeof(Ent_Structure_Window) });
		public static ByTable rad_collectors = new ByTable();
		public static readonly string RADIO_AIRLOCK = "6";
		public static readonly string RADIO_ATMOSIA = "4";
		public static readonly string RADIO_CHAT = "3";
		public static Subsystem_Radio radio_controller = null;
		public static readonly string RADIO_FROM_AIRALARM = "2";
		public static readonly string RADIO_MAGNETS = "9";
		public static readonly string RADIO_TO_AIRALARM = "1";
		public static readonly ByTable radiochannels = new ByTable().set( "AI Private", 1447 ).set( "Service", 1349 ).set( "Supply", 1347 ).set( "Syndicate", 1213 ).set( "Centcom", 1337 ).set( "Security", 1359 ).set( "Engineering", 1357 ).set( "Medical", 1355 ).set( "Command", 1353 ).set( "Science", 1351 ).set( "Common", 1459 );
		public static readonly ByTable radiochannelsreverse = new ByTable().set( "1447", "AI Private" ).set( "1349", "Service" ).set( "1347", "Supply" ).set( "1213", "Syndicate" ).set( "1337", "Centcom" ).set( "1359", "Security" ).set( "1357", "Engineering" ).set( "1355", "Medical" ).set( "1353", "Command" ).set( "1351", "Science" ).set( "1459", "Common" );
		public static ByTable rcd_list = new ByTable();
		public static ByTable recentmessages = new ByTable();
		public static readonly int record_id_num = 1001;
		public static ByTable req_console_assistance = new ByTable();
		public static ByTable req_console_information = new ByTable();
		public static ByTable req_console_supplies = new ByTable();
		public static readonly Getrev revdata = new Getrev();
		public static ByTable rockTurfEdgeCache = null;
		public static readonly ByTable rod_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 10 ).set( 3, 2 ).set( 2, typeof(Ent_Structure_Grille) ).set( 1, "grille" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 10 ).set( 3, 2 ).set( 2, typeof(Ent_Structure_TableFrame) ).set( 1, "table frame" ).applyCtor( typeof(StackRecipe) ) });
		public static readonly int ROOM_ERR_SPACE = -1;
		public static readonly int ROOM_ERR_TOOLARGE = -2;
		public static double round_start_time = 0;
		public static readonly ByTable roundstart_species = new ByTable( 0 );
		public static readonly ByTable RPD_recipes = new ByTable()
			.set( "Disposal Pipes", new ByTable().set( "Sort Junction", new PipeInfo_Disposal( 9, 2 ) ).set( "Chute", new PipeInfo_Disposal( 8, 4 ) ).set( "Outlet", new PipeInfo_Disposal( 7, 4 ) ).set( "Bin", new PipeInfo_Disposal( 6, 5 ) ).set( "Trunk", new PipeInfo_Disposal( 5, 2 ) ).set( "Y-Junction", new PipeInfo_Disposal( 4, 2 ) ).set( "Junction", new PipeInfo_Disposal( 2, 2 ) ).set( "Bent Pipe", new PipeInfo_Disposal( 1, 2 ) ).set( "Pipe", new PipeInfo_Disposal( 0, 0 ) ) )
			.set( "Heat Exchange", new ByTable().set( "Heat Exchanger", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Unary_HeatExchanger), 1, 4 ) ).set( "Junction", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Junction), 1, 4 ) ).set( "4-Way Manifold", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold4w), 1, 5 ) ).set( "Manifold", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Manifold), 1, 2 ) ).set( "Pipe", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Pipe_HeatExchanging_Simple), 1, 1 ) ) )
			.set( "Devices", new ByTable().set( "Gas Mixer", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Trinary_Mixer), 1, 3 ) ).set( "Gas Filter", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Trinary_Filter), 1, 3 ) ).set( "Meter", new PipeInfo_Meter() ).set( "Scrubber", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Unary_VentScrubber), 1, 4 ) ).set( "Volume Pump", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Binary_VolumePump), 1, 4 ) ).set( "Passive Gate", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Binary_PassiveGate), 1, 4 ) ).set( "Gas Pump", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Binary_Pump), 1, 4 ) ).set( "Unary Vent", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Unary_VentPump), 1, 4 ) ).set( "Connector", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Unary_PortablesConnector), 1, 4 ) ) )
			.set( "Regular Pipes", new ByTable().set( "4-Way Manifold", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Pipe_Manifold4w), 1, 5 ) ).set( "Digital Valve", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Binary_Valve_Digital), 1, 0 ) ).set( "Manual Valve", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Components_Binary_Valve), 1, 0 ) ).set( "Manifold", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Pipe_Manifold), 1, 2 ) ).set( "Pipe", new PipeInfo( typeof(Ent_Machinery_Atmospherics_Pipe_Simple), 1, 1 ) ) )
			
		;
		public static readonly ByTable runed_metal_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 40 ).set( 3, 4 ).set( 2, typeof(Ent_Structure_Cult_Pylon) ).set( 1, "pylon" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 40 ).set( 3, 6 ).set( 2, typeof(Ent_Structure_Cult_Forge) ).set( 1, "forge" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 40 ).set( 3, 4 ).set( 2, typeof(Ent_Structure_Cult_Tome) ).set( 1, "archives" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 40 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_Cult_Talisman) ).set( 1, "altar" ).applyCtor( typeof(StackRecipe) ) });
		public static readonly ByTable sacrificed = new ByTable();
		public static readonly int SAFETY_COOLDOWN = 100;
		public static readonly ByTable same_wires = new ByTable();
		public static readonly ByTable sandstone_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 10 ).set( 3, 3 ).set( 2, typeof(Ent_Machinery_Hydroponics_Soil) ).set( 1, "pile of dirt" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_MineralDoor_Sandstone) ).set( 1, "sandstone door" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Sandstone_Assistant) ).set( 1, "Assistant Statue" ).applyCtor( typeof(StackRecipe) ) });
		public static dynamic say_disabled = 0;
		public static readonly string sc_safecode1 = "";
		public static readonly string sc_safecode2 = "";
		public static readonly string sc_safecode3 = "";
		public static readonly string sc_safecode4 = "";
		public static readonly string sc_safecode5 = "";
		public static readonly ByTable scarySounds = new ByTable(new object [] { "sound/weapons/thudswoosh.ogg", "sound/weapons/Taser.ogg", "sound/weapons/armbomb.ogg", "sound/voice/hiss1.ogg", "sound/voice/hiss2.ogg", "sound/voice/hiss3.ogg", "sound/voice/hiss4.ogg", "sound/voice/hiss5.ogg", "sound/voice/hiss6.ogg", "sound/effects/Glassbr1.ogg", "sound/effects/Glassbr2.ogg", "sound/effects/Glassbr3.ogg", "sound/items/Welder.ogg", "sound/items/Welder2.ogg", "sound/machines/airlock.ogg", "sound/effects/clownstep1.ogg", "sound/effects/clownstep2.ogg" });
		public static readonly int SCI_FREQ = 1351;
		public static readonly ByTable science_positions = new ByTable(new object [] { "Research Director", "Scientist", "Roboticist" });
		public static ByTable sec_departments = new ByTable(new object [] { "engineering", "supply", "medical", "science" });
		public static readonly int SEC_FREQ = 1359;
		public static ByTable secequipment = new ByTable();
		public static dynamic secret_force_mode = "secret";
		public static int security_level = 0;
		public static readonly ByTable security_positions = new ByTable(new object [] { "Head of Security", "Warden", "Detective", "Security Officer" });
		public static readonly int SEE_MOBS = 4;
		public static readonly int SEE_OBJS = 8;
		public static readonly int SEE_SELF = 32;
		public static readonly int SEE_TURFS = 16;
		public static readonly int SERV_FREQ = 1349;
		public static ByTable shuttle_caller_list = new ByTable();
		public static readonly ByTable silver_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_MineralDoor_Silver) ).set( 1, "silver door" ).applyCtor( typeof(StackRecipe) ), new StackRecipe( "silver tile", typeof(Ent_Item_Stack_Tile_Mineral_Silver), 1, 4, 20 ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Silver_Md) ).set( 1, "Med Officer Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Silver_Janitor) ).set( 1, "Janitor Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Silver_Sec) ).set( 1, "Sec Officer Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Silver_Secborg) ).set( 1, "Sec Borg Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Silver_Medborg) ).set( 1, "Med Borg Statue" ).applyCtor( typeof(StackRecipe) ) });
		public static readonly ByTable skin_tones = new ByTable(new object [] { "albino", "caucasian1", "caucasian2", "caucasian3", "latino", "mediterranean", "asian1", "asian2", "arab", "indian", "african1", "african2" });
		public static readonly ByTable slot_equipment_priority = new ByTable(new object [] { 1, 7, 14, 13, 2, 11, 12, 10, 8, 9, 6, 17, 15, 16 });
		public static readonly ByTable slot2slot = new ByTable().set( "s_store", 17 ).set( "wear_id", 7 ).set( "ears", 8 ).set( "glasses", 9 ).set( "gloves", 10 ).set( "belt", 6 ).set( "shoes", 12 ).set( "w_uniform", 14 ).set( "wear_suit", 13 ).set( "back", 1 ).set( "wear_mask", 2 ).set( "head", 11 );
		public static readonly ByTable slot2type = new ByTable().set( "s_store", typeof(Ent_Item_Changeling) ).set( "wear_id", typeof(Ent_Item_Changeling) ).set( "ears", typeof(Ent_Item_Changeling) ).set( "glasses", typeof(Ent_Item_Clothing_Glasses_Changeling) ).set( "gloves", typeof(Ent_Item_Clothing_Gloves_Changeling) ).set( "belt", typeof(Ent_Item_Changeling) ).set( "shoes", typeof(Ent_Item_Clothing_Shoes_Changeling) ).set( "w_uniform", typeof(Ent_Item_Clothing_Under_Changeling) ).set( "wear_suit", typeof(Ent_Item_Clothing_Suit_Changeling) ).set( "back", typeof(Ent_Item_Changeling) ).set( "wear_mask", typeof(Ent_Item_Clothing_Mask_Changeling) ).set( "head", typeof(Ent_Item_Clothing_Head_Changeling) );
		public static readonly ByTable slots = new ByTable(new object [] { "head", "wear_mask", "back", "wear_suit", "w_uniform", "shoes", "belt", "gloves", "glasses", "ears", "wear_id", "s_store" });
		public static ByTable smesImageCache = null;
		public static readonly ByTable snouts_list = new ByTable();
		public static readonly ByTable socks_f = new ByTable();
		public static readonly ByTable socks_list = new ByTable();
		public static readonly ByTable socks_m = new ByTable();
		public static readonly ByTable sortedAreas = new ByTable();
		public static readonly SortInstance sortInstance = new SortInstance();
		public static readonly int SOUND_PAUSED = 2;
		public static readonly int SOUND_STREAM = 4;
		public static readonly int SOUTH = 2;
		public static readonly int SOUTHEAST = 6;
		public static readonly int SOUTHWEST = 10;
		public static readonly ByTable spawn_forbidden = new ByTable(new object [] { typeof(Ent_Item_Weapon_Grab), typeof(Ent_Item_TkGrab), typeof(Ent_Item_Weapon_Implant), typeof(Ent_Item_Assembly), typeof(Ent_Item_Device_Onetankbomb), typeof(Ent_Item_Radio), typeof(Ent_Item_Device_Pda_Ai), typeof(Ent_Item_Device_Uplink_Hidden), typeof(Ent_Item_SmallDelivery), typeof(Ent_Item_Missile), typeof(Ent_Item_Projectile), typeof(Ent_Item_Borg_Sight), typeof(Ent_Item_Borg_Stun), typeof(Ent_Item_Weapon_RobotModule) });
		public static readonly int SPAWN_HEAT = 1;
		public static readonly int SPAWN_OXYGEN = 8;
		public static readonly ByTable special_roles = new ByTable().set( "abductor", typeof(GameMode_Abduction) ).set( "shadowling", typeof(GameMode_Shadowling) ).set( "gangster", typeof(GameMode_Gang) ).set( "monkey", typeof(GameMode_Monkey) ).set( 11, "ninja" ).set( "blob", typeof(GameMode_Blob) ).set( "cultist", typeof(GameMode_Cult) ).set( 8, "pAI/posibrain" ).set( 7, "alien" ).set( "revolutionary", typeof(GameMode_Revolution) ).set( "malf AI", typeof(GameMode_Malfunction) ).set( "wizard", typeof(GameMode_Wizard) ).set( "changeling", typeof(GameMode_Changeling) ).set( "operative", typeof(GameMode_Nuclear) ).set( "traitor", typeof(GameMode_Traitor) );
		public static readonly ByTable species_list = new ByTable( 0 );
		public static readonly dynamic spells = Misc13.types( typeof(Ent_Effect_ProcHolder_Spell) );
		public static readonly ByTable spines_list = new ByTable();
		public static string sqladdress = "localhost";
		public static string sqlfdbkdb = "test";
		public static string sqlfdbklogin = "root";
		public static string sqlfdbkpass = "";
		public static string sqlfdbktableprefix = "erro_";
		public static string sqlport = "3306";
		public static readonly ByTable sqrtTable = new ByTable(new object [] { 1, 1, 1, 2, 2, 2, 2, 2, 3, 3, 3, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, 4, 4, 4, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 10 });
		public static Subsystem_Air SSair = null;
		public static Subsystem_Bots SSbot = null;
		public static Subsystem_Npcpool SSbp = null;
		public static Subsystem_Diseases SSdisease = null;
		public static Subsystem_Events SSevent = null;
		public static Subsystem_GarbageCollector SSgarbage = null;
		public static Subsystem_Job SSjob = null;
		public static Subsystem_Lighting SSlighting = null;
		public static Subsystem_Machines SSmachine = null;
		public static Subsystem_Mobs SSmob = null;
		public static Subsystem_Nano SSnano = null;
		public static Subsystem_Objects SSobj = null;
		public static Subsystem_Pai SSpai = null;
		public static Subsystem_Shuttle SSshuttle = null;
		public static Subsystem_Sun SSsun = null;
		public static Subsystem_Timer SStimer = null;
		public static Subsystem_Vote SSvote = null;
		public static ByTable start_landmarks_list = new ByTable();
		public static StationState start_state = null;
		public static readonly int STATE_ALERT_LEVEL = 8;
		public static readonly int STATE_CALLSHUTTLE = 2;
		public static readonly int STATE_CANCELSHUTTLE = 3;
		public static readonly int STATE_CONFIRM_LEVEL = 9;
		public static readonly int STATE_DEFAULT = 1;
		public static readonly int STATE_DELMESSAGE = 6;
		public static readonly int STATE_MESSAGELIST = 4;
		public static readonly int STATE_STATUSDISPLAY = 7;
		public static readonly int STATE_TOGGLE_EMERGENCY = 10;
		public static readonly int STATE_VIEWMESSAGE = 5;
		public static dynamic station_name = null;
		public static int status_overlays = 0;
		public static ByTable status_overlays_charging = null;
		public static ByTable status_overlays_environ = null;
		public static ByTable status_overlays_equipment = null;
		public static ByTable status_overlays_lighting = null;
		public static ByTable status_overlays_lock = null;
		public static readonly ByTable stealthminID = new ByTable();
		public static dynamic sting_paths = null;
		public static ByTable string_cache = null;
		public static readonly int SUPP_FREQ = 1347;
		public static readonly int supply_emergency = 1;
		public static readonly int supply_engineer = 3;
		public static readonly int supply_materials = 7;
		public static readonly int supply_medical = 4;
		public static readonly int supply_misc = 8;
		public static readonly int supply_organic = 6;
		public static readonly ByTable supply_positions = new ByTable(new object [] { "Head of Personnel", "Quartermaster", "Cargo Technician", "Shaft Miner" });
		public static readonly int supply_science = 5;
		public static readonly int supply_security = 2;
		public static readonly ByTable surgeries_list = new ByTable();
		public static ByTable swapmaps_byname = null;
		public static dynamic swapmaps_compiled_maxx = null;
		public static dynamic swapmaps_compiled_maxy = null;
		public static dynamic swapmaps_compiled_maxz = null;
		public static readonly dynamic swapmaps_iconcache = null;
		public static int swapmaps_initialized = 0;
		public static ByTable swapmaps_loaded = null;
		public static readonly int swapmaps_mode = 0;
		public static readonly int SYMPTOM_ACTIVATION_PROB = 3;
		public static readonly int SYND_FREQ = 1213;
		public static dynamic syndicate_code_phrase = null;
		public static dynamic syndicate_code_response = null;
		public static string syndicate_name = "";
		public static readonly string TAB = "&nbsp;&nbsp;&nbsp;&nbsp;";
		public static readonly ByTable table_recipes = new ByTable();
		public static readonly ByTable TAGGERLOCATIONS = new ByTable(new object [] { "Disposals", "Cargo Bay", "QM Office", "Engineering", "CE Office", "Atmospherics", "Security", "HoS Office", "Medbay", "CMO Office", "Chemistry", "Research", "RD Office", "Robotics", "HoP Office", "Library", "Chapel", "Theatre", "Bar", "Kitchen", "Hydroponics", "Janitor Closet", "Genetics" });
		public static readonly ByTable tails_list_human = new ByTable();
		public static readonly ByTable tails_list_lizard = new ByTable();
		public static ByTable tdome1 = new ByTable();
		public static ByTable tdome2 = new ByTable();
		public static ByTable tdomeadmin = new ByTable();
		public static ByTable tdomeobserve = new ByTable();
		public static ByTable telecomms_list = new ByTable();
		public static readonly ByTable teleport_other_runes = new ByTable();
		public static readonly ByTable teleport_runes = new ByTable();
		public static readonly ByTable teleportlocs = new ByTable();
		public static Ent_Machinery_Gateway_Centerstation the_gateway = null;
		public static readonly ByTable the_station_areas = new ByTable(new object [] { typeof(Zone_Atmos), typeof(Zone_Maintenance), typeof(Zone_Hallway), typeof(Zone_Bridge), typeof(Zone_CrewQuarters), typeof(Zone_Holodeck), typeof(Zone_Library), typeof(Zone_Chapel), typeof(Zone_Lawoffice), typeof(Zone_Engine), typeof(Zone_Solar), typeof(Zone_Assembly), typeof(Zone_Teleporter), typeof(Zone_Medical), typeof(Zone_Security), typeof(Zone_Quartermaster), typeof(Zone_Janitor), typeof(Zone_Hydroponics), typeof(Zone_Toxins), typeof(Zone_Storage), typeof(Zone_Construction), typeof(Zone_AiMonitored_Storage_Eva), typeof(Zone_TurretProtected_AiUpload), typeof(Zone_TurretProtected_AiUploadFoyer), typeof(Zone_TurretProtected_Ai) });
		public static Subsystem_Ticker ticker = null;
		public static double time_last_changed_position = 0;
		public static readonly int timezoneOffset = 0;
		public static dynamic tinted_weldhelh = 1;
		public static readonly int tk_maxrange = 15;
		public static readonly int TOUCH = 1;
		public static ByTable tracked_implants = new ByTable();
		public static readonly int TRUE = 1;
		public static readonly ByTable tube_dir_list = new ByTable(new object [] { GlobalVars.NORTH, GlobalVars.SOUTH, GlobalVars.EAST, GlobalVars.WEST, GlobalVars.NORTHEAST, GlobalVars.NORTHWEST, GlobalVars.SOUTHEAST, GlobalVars.SOUTHWEST });
		public static readonly int TURF_LAYER = 2;
		public static readonly ByTable TYPES_SHORTCUTS = new ByTable().set( typeof(Ent_Item_Organ_Internal), "ORGAN_INT" ).set( typeof(Ent_Item_MechaParts_MechaEquipment), "MECHA_EQUIP" ).set( typeof(Ent_Item_MechaParts_MechaEquipment_Weapon_Ballistic_Launcher_MissileRack), "MECHA_MISSILE_RACK" ).set( typeof(Ent_Machinery_PortableAtmospherics), "PORT_ATMOS" ).set( typeof(Ent_Machinery_Atmospherics), "ATMOS" ).set( typeof(Ent_Item_Weapon_ReagentContainers), "REAGENT_CONTAINERS" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food), "FOOD" ).set( typeof(Ent_Item_Weapon_ReagentContainers_Food_Drinks), "DRINK" ).set( typeof(Ent_Item_Weapon_Book_Manual), "MANUAL" ).set( typeof(Ent_Item_Clothing_Head_Helmet_Space), "SPESSHELMET" ).set( typeof(Ent_Item_Device_Radio_Headset), "HEADSET" ).set( typeof(Ent_Effect_Decal_Cleanable), "CLEANABLE" );
		public static readonly ByTable undershirt_f = new ByTable();
		public static readonly ByTable undershirt_list = new ByTable();
		public static readonly ByTable undershirt_m = new ByTable();
		public static readonly ByTable underwear_f = new ByTable();
		public static readonly ByTable underwear_list = new ByTable();
		public static readonly ByTable underwear_m = new ByTable();
		public static readonly ByTable uplink_items = new ByTable();
		public static readonly ByTable uranium_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_MineralDoor_Uranium) ).set( 1, "uranium door" ).applyCtor( typeof(StackRecipe) ), new StackRecipe( "uranium tile", typeof(Ent_Item_Stack_Tile_Mineral_Uranium), 1, 4, 20 ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Uranium_Nuke) ).set( 1, "Nuke Statue" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Statue_Uranium_Eng) ).set( 1, "Engineer Statue" ).applyCtor( typeof(StackRecipe) ) });
		public static readonly int VAPOR = 3;
		public static readonly ByTable ventcrawl_machinery = new ByTable(new object [] { typeof(Ent_Machinery_Atmospherics_Components_Unary_VentPump), typeof(Ent_Machinery_Atmospherics_Components_Unary_VentScrubber) });
		public static readonly dynamic verbs = GlobalFuncs.file2list( "config/names/verbs.txt" );
		public static readonly int VOX_CHANNEL = 200;
		public static readonly ByTable vox_sounds = new ByTable().set( "zulu", "sound/vox_fem/zulu.ogg" ).set( "zone", "sound/vox_fem/zone.ogg" ).set( "zero", "sound/vox_fem/zero.ogg" ).set( "z", "sound/vox_fem/z.ogg" ).set( "yourself", "sound/vox_fem/yourself.ogg" ).set( "your", "sound/vox_fem/your.ogg" ).set( "you", "sound/vox_fem/you.ogg" ).set( "yes", "sound/vox_fem/yes.ogg" ).set( "yellow", "sound/vox_fem/yellow.ogg" ).set( "year", "sound/vox_fem/year.ogg" ).set( "yards", "sound/vox_fem/yards.ogg" ).set( "yankee", "sound/vox_fem/yankee.ogg" ).set( "y", "sound/vox_fem/y.ogg" ).set( "xenomorphs", "sound/vox_fem/xenomorphs.ogg" ).set( "xenomorph", "sound/vox_fem/xenomorph.ogg" ).set( "xenobiology", "sound/vox_fem/xenobiology.ogg" ).set( "xeno", "sound/vox_fem/xeno.ogg" ).set( "x", "sound/vox_fem/x.ogg" ).set( "woody", "sound/vox_fem/woody.ogg" ).set( "wood", "sound/vox_fem/wood.ogg" ).set( "without", "sound/vox_fem/without.ogg" ).set( "with", "sound/vox_fem/with.ogg" ).set( "will", "sound/vox_fem/will.ogg" ).set( "wilco", "sound/vox_fem/wilco.ogg" ).set( "white", "sound/vox_fem/white.ogg" ).set( "whiskey", "sound/vox_fem/whiskey.ogg" ).set( "west", "sound/vox_fem/west.ogg" ).set( "welcome", "sound/vox_fem/welcome.ogg" ).set( "weapon", "sound/vox_fem/weapon.ogg" ).set( "we", "sound/vox_fem/we.ogg" ).set( "water", "sound/vox_fem/water.ogg" ).set( "waste", "sound/vox_fem/waste.ogg" ).set( "warning", "sound/vox_fem/warning.ogg" ).set( "warn", "sound/vox_fem/warn.ogg" ).set( "warm", "sound/vox_fem/warm.ogg" ).set( "wanted", "sound/vox_fem/wanted.ogg" ).set( "want", "sound/vox_fem/want.ogg" ).set( "wanker", "sound/vox_fem/wanker.ogg" ).set( "wall", "sound/vox_fem/wall.ogg" ).set( "walk", "sound/vox_fem/walk.ogg" ).set( "w", "sound/vox_fem/w.ogg" ).set( "voxtest", "sound/vox_fem/voxtest.ogg" ).set( "vox_login", "sound/vox_fem/vox_login.ogg" ).set( "vox", "sound/vox_fem/vox.ogg" ).set( "voltage", "sound/vox_fem/voltage.ogg" ).set( "virology", "sound/vox_fem/virology.ogg" ).set( "violation", "sound/vox_fem/violation.ogg" ).set( "violated", "sound/vox_fem/violated.ogg" ).set( "victor", "sound/vox_fem/victor.ogg" ).set( "ventilation", "sound/vox_fem/ventilation.ogg" ).set( "vent", "sound/vox_fem/vent.ogg" ).set( "vapor", "sound/vox_fem/vapor.ogg" ).set( "valid", "sound/vox_fem/valid.ogg" ).set( "vacate", "sound/vox_fem/vacate.ogg" ).set( "v", "sound/vox_fem/v.ogg" ).set( "user", "sound/vox_fem/user.ogg" ).set( "used", "sound/vox_fem/used.ogg" ).set( "use", "sound/vox_fem/use.ogg" ).set( "usa", "sound/vox_fem/usa.ogg" ).set( "us", "sound/vox_fem/us.ogg" ).set( "uranium", "sound/vox_fem/uranium.ogg" ).set( "upper", "sound/vox_fem/upper.ogg" ).set( "upload", "sound/vox_fem/upload.ogg" ).set( "updating", "sound/vox_fem/updating.ogg" ).set( "updated", "sound/vox_fem/updated.ogg" ).set( "update", "sound/vox_fem/update.ogg" ).set( "up", "sound/vox_fem/up.ogg" ).set( "until", "sound/vox_fem/until.ogg" ).set( "unlocked", "sound/vox_fem/unlocked.ogg" ).set( "uniform", "sound/vox_fem/uniform.ogg" ).set( "under", "sound/vox_fem/under.ogg" ).set( "unauthorized", "sound/vox_fem/unauthorized.ogg" ).set( "u", "sound/vox_fem/u.ogg" ).set( "two", "sound/vox_fem/two.ogg" ).set( "twenty", "sound/vox_fem/twenty.ogg" ).set( "twelve", "sound/vox_fem/twelve.ogg" ).set( "turret", "sound/vox_fem/turret.ogg" ).set( "turn", "sound/vox_fem/turn.ogg" ).set( "tunnel", "sound/vox_fem/tunnel.ogg" ).set( "truck", "sound/vox_fem/truck.ogg" ).set( "transportation", "sound/vox_fem/transportation.ogg" ).set( "traitor", "sound/vox_fem/traitor.ogg" ).set( "train", "sound/vox_fem/train.ogg" ).set( "track", "sound/vox_fem/track.ogg" ).set( "toxins", "sound/vox_fem/toxins.ogg" ).set( "towards", "sound/vox_fem/towards.ogg" ).set( "touch", "sound/vox_fem/touch.ogg" ).set( "topside", "sound/vox_fem/topside.ogg" ).set( "top", "sound/vox_fem/top.ogg" ).set( "to", "sound/vox_fem/to.ogg" ).set( "time", "sound/vox_fem/time.ogg" ).set( "tide", "sound/vox_fem/tide.ogg" ).set( "through", "sound/vox_fem/through.ogg" ).set( "three", "sound/vox_fem/three.ogg" ).set( "threat", "sound/vox_fem/threat.ogg" ).set( "thousand", "sound/vox_fem/thousand.ogg" ).set( "those", "sound/vox_fem/those.ogg" ).set( "this", "sound/vox_fem/this.ogg" ).set( "thirty", "sound/vox_fem/thirty.ogg" ).set( "thirteen", "sound/vox_fem/thirteen.ogg" ).set( "third", "sound/vox_fem/third.ogg" ).set( "there", "sound/vox_fem/there.ogg" ).set( "then", "sound/vox_fem/then.ogg" ).set( "the", "sound/vox_fem/the.ogg" ).set( "that", "sound/vox_fem/that.ogg" ).set( "test", "sound/vox_fem/test.ogg" ).set( "termination", "sound/vox_fem/termination.ogg" ).set( "terminated", "sound/vox_fem/terminated.ogg" ).set( "terminal", "sound/vox_fem/terminal.ogg" ).set( "ten", "sound/vox_fem/ten.ogg" ).set( "temporal", "sound/vox_fem/temporal.ogg" ).set( "temperature", "sound/vox_fem/temperature.ogg" ).set( "team", "sound/vox_fem/team.ogg" ).set( "target", "sound/vox_fem/target.ogg" ).set( "tank", "sound/vox_fem/tank.ogg" ).set( "tango", "sound/vox_fem/tango.ogg" ).set( "talk", "sound/vox_fem/talk.ogg" ).set( "take", "sound/vox_fem/take.ogg" ).set( "tactical", "sound/vox_fem/tactical.ogg" ).set( "t", "sound/vox_fem/t.ogg" ).set( "systems", "sound/vox_fem/systems.ogg" ).set( "system", "sound/vox_fem/system.ogg" ).set( "syndicate", "sound/vox_fem/syndicate.ogg" ).set( "switch", "sound/vox_fem/switch.ogg" ).set( "surrounded", "sound/vox_fem/surrounded.ogg" ).set( "surround", "sound/vox_fem/surround.ogg" ).set( "surrender", "sound/vox_fem/surrender.ogg" ).set( "surface", "sound/vox_fem/surface.ogg" ).set( "supply", "sound/vox_fem/supply.ogg" ).set( "supercooled", "sound/vox_fem/supercooled.ogg" ).set( "superconducting", "sound/vox_fem/superconducting.ogg" ).set( "suit", "sound/vox_fem/suit.ogg" ).set( "suffer", "sound/vox_fem/suffer.ogg" ).set( "sudden", "sound/vox_fem/sudden.ogg" ).set( "subsurface", "sound/vox_fem/subsurface.ogg" ).set( "sub", "sound/vox_fem/sub.ogg" ).set( "stuck", "sound/vox_fem/stuck.ogg" ).set( "storage", "sound/vox_fem/storage.ogg" ).set( "sterilization", "sound/vox_fem/sterilization.ogg" ).set( "sterile", "sound/vox_fem/sterile.ogg" ).set( "status", "sound/vox_fem/status.ogg" ).set( "station", "sound/vox_fem/station.ogg" ).set( "starboard", "sound/vox_fem/starboard.ogg" ).set( "stairway", "sound/vox_fem/stairway.ogg" ).set( "ss13", "sound/vox_fem/ss13.ogg" ).set( "square", "sound/vox_fem/square.ogg" ).set( "squad", "sound/vox_fem/squad.ogg" ).set( "south", "sound/vox_fem/south.ogg" ).set( "sorry", "sound/vox_fem/sorry.ogg" ).set( "son", "sound/vox_fem/son.ogg" ).set( "something", "sound/vox_fem/something.ogg" ).set( "someone", "sound/vox_fem/someone.ogg" ).set( "some", "sound/vox_fem/some.ogg" ).set( "soldier", "sound/vox_fem/soldier.ogg" ).set( "solars", "sound/vox_fem/solars.ogg" ).set( "solar", "sound/vox_fem/solar.ogg" ).set( "slow", "sound/vox_fem/slow.ogg" ).set( "slime", "sound/vox_fem/slime.ogg" ).set( "sixty", "sound/vox_fem/sixty.ogg" ).set( "sixteen", "sound/vox_fem/sixteen.ogg" ).set( "six", "sound/vox_fem/six.ogg" ).set( "singularity", "sound/vox_fem/singularity.ogg" ).set( "silo", "sound/vox_fem/silo.ogg" ).set( "sight", "sound/vox_fem/sight.ogg" ).set( "sierra", "sound/vox_fem/sierra.ogg" ).set( "side", "sound/vox_fem/side.ogg" ).set( "shuttle", "sound/vox_fem/shuttle.ogg" ).set( "shut", "sound/vox_fem/shut.ogg" ).set( "shower", "sound/vox_fem/shower.ogg" ).set( "shoot", "sound/vox_fem/shoot.ogg" ).set( "shock", "sound/vox_fem/shock.ogg" ).set( "shitting", "sound/vox_fem/shitting.ogg" ).set( "shits", "sound/vox_fem/shits.ogg" ).set( "shitlord", "sound/vox_fem/shitlord.ogg" ).set( "shit", "sound/vox_fem/shit.ogg" ).set( "shirt", "sound/vox_fem/shirt.ogg" ).set( "shipment", "sound/vox_fem/shipment.ogg" ).set( "shield", "sound/vox_fem/shield.ogg" ).set( "sewer", "sound/vox_fem/sewer.ogg" ).set( "sewage", "sound/vox_fem/sewage.ogg" ).set( "severe", "sound/vox_fem/severe.ogg" ).set( "seventy", "sound/vox_fem/seventy.ogg" ).set( "seventeen", "sound/vox_fem/seventeen.ogg" ).set( "seven", "sound/vox_fem/seven.ogg" ).set( "service", "sound/vox_fem/service.ogg" ).set( "sensors", "sound/vox_fem/sensors.ogg" ).set( "selected", "sound/vox_fem/selected.ogg" ).set( "select", "sound/vox_fem/select.ogg" ).set( "security", "sound/vox_fem/security.ogg" ).set( "secured", "sound/vox_fem/secured.ogg" ).set( "secure", "sound/vox_fem/secure.ogg" ).set( "sector", "sound/vox_fem/sector.ogg" ).set( "seconds", "sound/vox_fem/seconds.ogg" ).set( "secondary", "sound/vox_fem/secondary.ogg" ).set( "second", "sound/vox_fem/second.ogg" ).set( "search", "sound/vox_fem/search.ogg" ).set( "screen", "sound/vox_fem/screen.ogg" ).set( "scream", "sound/vox_fem/scream.ogg" ).set( "science", "sound/vox_fem/science.ogg" ).set( "save", "sound/vox_fem/save.ogg" ).set( "satellite", "sound/vox_fem/satellite.ogg" ).set( "sargeant", "sound/vox_fem/sargeant.ogg" ).set( "sarah", "sound/vox_fem/sarah.ogg" ).set( "safety", "sound/vox_fem/safety.ogg" ).set( "safe", "sound/vox_fem/safe.ogg" ).set( "s", "sound/vox_fem/s.ogg" ).set( "run", "sound/vox_fem/run.ogg" ).set( "round", "sound/vox_fem/round.ogg" ).set( "room", "sound/vox_fem/room.ogg" ).set( "romeo", "sound/vox_fem/romeo.ogg" ).set( "roger", "sound/vox_fem/roger.ogg" ).set( "rocket", "sound/vox_fem/rocket.ogg" ).set( "right", "sound/vox_fem/right.ogg" ).set( "rest", "sound/vox_fem/rest.ogg" ).set( "resistance", "sound/vox_fem/resistance.ogg" ).set( "resevoir", "sound/vox_fem/resevoir.ogg" ).set( "research", "sound/vox_fem/research.ogg" ).set( "required", "sound/vox_fem/required.ogg" ).set( "reports", "sound/vox_fem/reports.ogg" ).set( "report", "sound/vox_fem/report.ogg" ).set( "repair", "sound/vox_fem/repair.ogg" ).set( "renegade", "sound/vox_fem/renegade.ogg" ).set( "removal", "sound/vox_fem/removal.ogg" ).set( "remaining", "sound/vox_fem/remaining.ogg" ).set( "released", "sound/vox_fem/released.ogg" ).set( "relay", "sound/vox_fem/relay.ogg" ).set( "red", "sound/vox_fem/red.ogg" ).set( "reactor", "sound/vox_fem/reactor.ogg" ).set( "reached", "sound/vox_fem/reached.ogg" ).set( "reach", "sound/vox_fem/reach.ogg" ).set( "rapid", "sound/vox_fem/rapid.ogg" ).set( "raiders", "sound/vox_fem/raiders.ogg" ).set( "raider", "sound/vox_fem/raider.ogg" ).set( "rads", "sound/vox_fem/rads.ogg" ).set( "radioactive", "sound/vox_fem/radioactive.ogg" ).set( "radiation", "sound/vox_fem/radiation.ogg" ).set( "r", "sound/vox_fem/r.ogg" ).set( "quit", "sound/vox_fem/quit.ogg" ).set( "quick", "sound/vox_fem/quick.ogg" ).set( "questioning", "sound/vox_fem/questioning.ogg" ).set( "question", "sound/vox_fem/question.ogg" ).set( "queen", "sound/vox_fem/queen.ogg" ).set( "quebec", "sound/vox_fem/quebec.ogg" ).set( "quantum", "sound/vox_fem/quantum.ogg" ).set( "q", "sound/vox_fem/q.ogg" ).set( "push", "sound/vox_fem/push.ogg" ).set( "protective", "sound/vox_fem/protective.ogg" ).set( "prosecute", "sound/vox_fem/prosecute.ogg" ).set( "propulsion", "sound/vox_fem/propulsion.ogg" ).set( "proper", "sound/vox_fem/proper.ogg" ).set( "progress", "sound/vox_fem/progress.ogg" ).set( "processing", "sound/vox_fem/processing.ogg" ).set( "proceed", "sound/vox_fem/proceed.ogg" ).set( "primary", "sound/vox_fem/primary.ogg" ).set( "press", "sound/vox_fem/press.ogg" ).set( "presence", "sound/vox_fem/presence.ogg" ).set( "power", "sound/vox_fem/power.ogg" ).set( "portal", "sound/vox_fem/portal.ogg" ).set( "port", "sound/vox_fem/port.ogg" ).set( "point", "sound/vox_fem/point.ogg" ).set( "please", "sound/vox_fem/please.ogg" ).set( "platform", "sound/vox_fem/platform.ogg" ).set( "plasma", "sound/vox_fem/plasma.ogg" ).set( "plant", "sound/vox_fem/plant.ogg" ).set( "pipe", "sound/vox_fem/pipe.ogg" ).set( "personnel", "sound/vox_fem/personnel.ogg" ).set( "permitted", "sound/vox_fem/permitted.ogg" ).set( "perimeter", "sound/vox_fem/perimeter.ogg" ).set( "percent", "sound/vox_fem/percent.ogg" ).set( "panel", "sound/vox_fem/panel.ogg" ).set( "pal", "sound/vox_fem/pal.ogg" ).set( "pain", "sound/vox_fem/pain.ogg" ).set( "pacify", "sound/vox_fem/pacify.ogg" ).set( "p", "sound/vox_fem/p.ogg" ).set( "override", "sound/vox_fem/override.ogg" ).set( "overload", "sound/vox_fem/overload.ogg" ).set( "over", "sound/vox_fem/over.ogg" ).set( "outside", "sound/vox_fem/outside.ogg" ).set( "out", "sound/vox_fem/out.ogg" ).set( "oscar", "sound/vox_fem/oscar.ogg" ).set( "organic", "sound/vox_fem/organic.ogg" ).set( "order", "sound/vox_fem/order.ogg" ).set( "option", "sound/vox_fem/option.ogg" ).set( "operative", "sound/vox_fem/operative.ogg" ).set( "operations", "sound/vox_fem/operations.ogg" ).set( "operating", "sound/vox_fem/operating.ogg" ).set( "open", "sound/vox_fem/open.ogg" ).set( "one", "sound/vox_fem/one.ogg" ).set( "on", "sound/vox_fem/on.ogg" ).set( "ok", "sound/vox_fem/ok.ogg" ).set( "officer", "sound/vox_fem/officer.ogg" ).set( "of", "sound/vox_fem/of.ogg" ).set( "obtain", "sound/vox_fem/obtain.ogg" ).set( "observation", "sound/vox_fem/observation.ogg" ).set( "objective", "sound/vox_fem/objective.ogg" ).set( "o", "sound/vox_fem/o.ogg" ).set( "number", "sound/vox_fem/number.ogg" ).set( "now", "sound/vox_fem/now.ogg" ).set( "november", "sound/vox_fem/november.ogg" ).set( "not", "sound/vox_fem/not.ogg" ).set( "north", "sound/vox_fem/north.ogg" ).set( "nominal", "sound/vox_fem/nominal.ogg" ).set( "no", "sound/vox_fem/no.ogg" ).set( "ninety", "sound/vox_fem/ninety.ogg" ).set( "nineteen", "sound/vox_fem/nineteen.ogg" ).set( "nine", "sound/vox_fem/nine.ogg" ).set( "nice", "sound/vox_fem/nice.ogg" ).set( "nearest", "sound/vox_fem/nearest.ogg" ).set( "nanotrasen", "sound/vox_fem/nanotrasen.ogg" ).set( "n", "sound/vox_fem/n.ogg" ).set( "my", "sound/vox_fem/my.ogg" ).set( "must", "sound/vox_fem/must.ogg" ).set( "move", "sound/vox_fem/move.ogg" ).set( "motorpool", "sound/vox_fem/motorpool.ogg" ).set( "motor", "sound/vox_fem/motor.ogg" ).set( "money", "sound/vox_fem/money.ogg" ).set( "mode", "sound/vox_fem/mode.ogg" ).set( "mister", "sound/vox_fem/mister.ogg" ).set( "minutes", "sound/vox_fem/minutes.ogg" ).set( "minimum", "sound/vox_fem/minimum.ogg" ).set( "minefield", "sound/vox_fem/minefield.ogg" ).set( "million", "sound/vox_fem/million.ogg" ).set( "milli", "sound/vox_fem/milli.ogg" ).set( "military", "sound/vox_fem/military.ogg" ).set( "miles", "sound/vox_fem/miles.ogg" ).set( "mike", "sound/vox_fem/mike.ogg" ).set( "middle", "sound/vox_fem/middle.ogg" ).set( "micro", "sound/vox_fem/micro.ogg" ).set( "meter", "sound/vox_fem/meter.ogg" ).set( "message", "sound/vox_fem/message.ogg" ).set( "mesa", "sound/vox_fem/mesa.ogg" ).set( "mercy", "sound/vox_fem/mercy.ogg" ).set( "men", "sound/vox_fem/men.ogg" ).set( "medical", "sound/vox_fem/medical.ogg" ).set( "medbay", "sound/vox_fem/medbay.ogg" ).set( "me", "sound/vox_fem/me.ogg" ).set( "may", "sound/vox_fem/may.ogg" ).set( "maximum", "sound/vox_fem/maximum.ogg" ).set( "materials", "sound/vox_fem/materials.ogg" ).set( "mass", "sound/vox_fem/mass.ogg" ).set( "man", "sound/vox_fem/man.ogg" ).set( "malfunction", "sound/vox_fem/malfunction.ogg" ).set( "maintenance", "sound/vox_fem/maintenance.ogg" ).set( "main", "sound/vox_fem/main.ogg" ).set( "magnetic", "sound/vox_fem/magnetic.ogg" ).set( "m", "sound/vox_fem/m.ogg" ).set( "lowest", "sound/vox_fem/lowest.ogg" ).set( "lower", "sound/vox_fem/lower.ogg" ).set( "loose", "sound/vox_fem/loose.ogg" ).set( "lockout", "sound/vox_fem/lockout.ogg" ).set( "locker", "sound/vox_fem/locker.ogg" ).set( "locked", "sound/vox_fem/locked.ogg" ).set( "lock", "sound/vox_fem/lock.ogg" ).set( "location", "sound/vox_fem/location.ogg" ).set( "located", "sound/vox_fem/located.ogg" ).set( "locate", "sound/vox_fem/locate.ogg" ).set( "loading", "sound/vox_fem/loading.ogg" ).set( "liquid", "sound/vox_fem/liquid.ogg" ).set( "lima", "sound/vox_fem/lima.ogg" ).set( "light", "sound/vox_fem/light.ogg" ).set( "life", "sound/vox_fem/life.ogg" ).set( "lieutenant", "sound/vox_fem/lieutenant.ogg" ).set( "lie", "sound/vox_fem/lie.ogg" ).set( "lever", "sound/vox_fem/lever.ogg" ).set( "level", "sound/vox_fem/level.ogg" ).set( "legal", "sound/vox_fem/legal.ogg" ).set( "left", "sound/vox_fem/left.ogg" ).set( "leave", "sound/vox_fem/leave.ogg" ).set( "leak", "sound/vox_fem/leak.ogg" ).set( "laws", "sound/vox_fem/laws.ogg" ).set( "law", "sound/vox_fem/law.ogg" ).set( "launch", "sound/vox_fem/launch.ogg" ).set( "last", "sound/vox_fem/last.ogg" ).set( "laser", "sound/vox_fem/laser.ogg" ).set( "lambda", "sound/vox_fem/lambda.ogg" ).set( "lab", "sound/vox_fem/lab.ogg" ).set( "l", "sound/vox_fem/l.ogg" ).set( "kit", "sound/vox_fem/kit.ogg" ).set( "kilo", "sound/vox_fem/kilo.ogg" ).set( "kill", "sound/vox_fem/kill.ogg" ).set( "key", "sound/vox_fem/key.ogg" ).set( "k", "sound/vox_fem/k.ogg" ).set( "juliet", "sound/vox_fem/juliet.ogg" ).set( "johnson", "sound/vox_fem/johnson.ogg" ).set( "j", "sound/vox_fem/j.ogg" ).set( "it", "sound/vox_fem/it.ogg" ).set( "is", "sound/vox_fem/is.ogg" ).set( "invasion", "sound/vox_fem/invasion.ogg" ).set( "invalid", "sound/vox_fem/invalid.ogg" ).set( "intruder", "sound/vox_fem/intruder.ogg" ).set( "interchange", "sound/vox_fem/interchange.ogg" ).set( "inspector", "sound/vox_fem/inspector.ogg" ).set( "inspection", "sound/vox_fem/inspection.ogg" ).set( "inside", "sound/vox_fem/inside.ogg" ).set( "inoperative", "sound/vox_fem/inoperative.ogg" ).set( "ing", "sound/vox_fem/ing.ogg" ).set( "india", "sound/vox_fem/india.ogg" ).set( "inches", "sound/vox_fem/inches.ogg" ).set( "in", "sound/vox_fem/in.ogg" ).set( "immediately", "sound/vox_fem/immediately.ogg" ).set( "immediate", "sound/vox_fem/immediate.ogg" ).set( "illegal", "sound/vox_fem/illegal.ogg" ).set( "idiot", "sound/vox_fem/idiot.ogg" ).set( "i", "sound/vox_fem/i.ogg" ).set( "hydroponics", "sound/vox_fem/hydroponics.ogg" ).set( "hydro", "sound/vox_fem/hydro.ogg" ).set( "hunger", "sound/vox_fem/hunger.ogg" ).set( "hundred", "sound/vox_fem/hundred.ogg" ).set( "human", "sound/vox_fem/human.ogg" ).set( "hours", "sound/vox_fem/hours.ogg" ).set( "hour", "sound/vox_fem/hour.ogg" ).set( "hotel", "sound/vox_fem/hotel.ogg" ).set( "hot", "sound/vox_fem/hot.ogg" ).set( "hostile", "sound/vox_fem/hostile.ogg" ).set( "hole", "sound/vox_fem/hole.ogg" ).set( "hit", "sound/vox_fem/hit.ogg" ).set( "highest", "sound/vox_fem/highest.ogg" ).set( "high", "sound/vox_fem/high.ogg" ).set( "hide", "sound/vox_fem/hide.ogg" ).set( "here", "sound/vox_fem/here.ogg" ).set( "help", "sound/vox_fem/help.ogg" ).set( "hello", "sound/vox_fem/hello.ogg" ).set( "helium", "sound/vox_fem/helium.ogg" ).set( "helicopter", "sound/vox_fem/helicopter.ogg" ).set( "heat", "sound/vox_fem/heat.ogg" ).set( "health", "sound/vox_fem/health.ogg" ).set( "head", "sound/vox_fem/head.ogg" ).set( "hazard", "sound/vox_fem/hazard.ogg" ).set( "have", "sound/vox_fem/have.ogg" ).set( "has", "sound/vox_fem/has.ogg" ).set( "harm", "sound/vox_fem/harm.ogg" ).set( "hangar", "sound/vox_fem/hangar.ogg" ).set( "handling", "sound/vox_fem/handling.ogg" ).set( "hackers", "sound/vox_fem/hackers.ogg" ).set( "hacker", "sound/vox_fem/hacker.ogg" ).set( "h", "sound/vox_fem/h.ogg" ).set( "guthrie", "sound/vox_fem/guthrie.ogg" ).set( "gun", "sound/vox_fem/gun.ogg" ).set( "gulf", "sound/vox_fem/gulf.ogg" ).set( "guard", "sound/vox_fem/guard.ogg" ).set( "grenade", "sound/vox_fem/grenade.ogg" ).set( "green", "sound/vox_fem/green.ogg" ).set( "great", "sound/vox_fem/great.ogg" ).set( "gray", "sound/vox_fem/gray.ogg" ).set( "granted", "sound/vox_fem/granted.ogg" ).set( "government", "sound/vox_fem/government.ogg" ).set( "got", "sound/vox_fem/got.ogg" ).set( "gordon", "sound/vox_fem/gordon.ogg" ).set( "goodbye", "sound/vox_fem/goodbye.ogg" ).set( "good", "sound/vox_fem/good.ogg" ).set( "going", "sound/vox_fem/going.ogg" ).set( "go", "sound/vox_fem/go.ogg" ).set( "glory", "sound/vox_fem/glory.ogg" ).set( "get", "sound/vox_fem/get.ogg" ).set( "gas", "sound/vox_fem/gas.ogg" ).set( "g", "sound/vox_fem/g.ogg" ).set( "fuel", "sound/vox_fem/fuel.ogg" ).set( "fucks", "sound/vox_fem/fucks.ogg" ).set( "fucking", "sound/vox_fem/fucking.ogg" ).set( "fuck", "sound/vox_fem/fuck.ogg" ).set( "front", "sound/vox_fem/front.ogg" ).set( "from", "sound/vox_fem/from.ogg" ).set( "freezer", "sound/vox_fem/freezer.ogg" ).set( "freeman", "sound/vox_fem/freeman.ogg" ).set( "foxtrot", "sound/vox_fem/foxtrot.ogg" ).set( "fourty", "sound/vox_fem/fourty.ogg" ).set( "fourth", "sound/vox_fem/fourth.ogg" ).set( "fourteen", "sound/vox_fem/fourteen.ogg" ).set( "four", "sound/vox_fem/four.ogg" ).set( "found", "sound/vox_fem/found.ogg" ).set( "forms", "sound/vox_fem/forms.ogg" ).set( "fore", "sound/vox_fem/fore.ogg" ).set( "force", "sound/vox_fem/force.ogg" ).set( "forbidden", "sound/vox_fem/forbidden.ogg" ).set( "for", "sound/vox_fem/for.ogg" ).set( "fool", "sound/vox_fem/fool.ogg" ).set( "floor", "sound/vox_fem/floor.ogg" ).set( "flooding", "sound/vox_fem/flooding.ogg" ).set( "five", "sound/vox_fem/five.ogg" ).set( "first", "sound/vox_fem/first.ogg" ).set( "fire", "sound/vox_fem/fire.ogg" ).set( "fine", "sound/vox_fem/fine.ogg" ).set( "final", "sound/vox_fem/final.ogg" ).set( "fifty", "sound/vox_fem/fifty.ogg" ).set( "fifth", "sound/vox_fem/fifth.ogg" ).set( "fifteen", "sound/vox_fem/fifteen.ogg" ).set( "field", "sound/vox_fem/field.ogg" ).set( "feet", "sound/vox_fem/feet.ogg" ).set( "fast", "sound/vox_fem/fast.ogg" ).set( "farthest", "sound/vox_fem/farthest.ogg" ).set( "failure", "sound/vox_fem/failure.ogg" ).set( "failed", "sound/vox_fem/failed.ogg" ).set( "fahrenheit", "sound/vox_fem/fahrenheit.ogg" ).set( "facility", "sound/vox_fem/facility.ogg" ).set( "f", "sound/vox_fem/f.ogg" ).set( "extreme", "sound/vox_fem/extreme.ogg" ).set( "extinguisher", "sound/vox_fem/extinguisher.ogg" ).set( "extinguish", "sound/vox_fem/extinguish.ogg" ).set( "exterminate", "sound/vox_fem/exterminate.ogg" ).set( "exposure", "sound/vox_fem/exposure.ogg" ).set( "explosion", "sound/vox_fem/explosion.ogg" ).set( "explode", "sound/vox_fem/explode.ogg" ).set( "experimental", "sound/vox_fem/experimental.ogg" ).set( "experiment", "sound/vox_fem/experiment.ogg" ).set( "expect", "sound/vox_fem/expect.ogg" ).set( "exit", "sound/vox_fem/exit.ogg" ).set( "exchange", "sound/vox_fem/exchange.ogg" ).set( "evacuate", "sound/vox_fem/evacuate.ogg" ).set( "escape", "sound/vox_fem/escape.ogg" ).set( "error", "sound/vox_fem/error.ogg" ).set( "environment", "sound/vox_fem/environment.ogg" ).set( "entry", "sound/vox_fem/entry.ogg" ).set( "enter", "sound/vox_fem/enter.ogg" ).set( "engine", "sound/vox_fem/engine.ogg" ).set( "engaged", "sound/vox_fem/engaged.ogg" ).set( "engage", "sound/vox_fem/engage.ogg" ).set( "energy", "sound/vox_fem/energy.ogg" ).set( "emergency", "sound/vox_fem/emergency.ogg" ).set( "eliminate", "sound/vox_fem/eliminate.ogg" ).set( "eleven", "sound/vox_fem/eleven.ogg" ).set( "elevator", "sound/vox_fem/elevator.ogg" ).set( "electromagnetic", "sound/vox_fem/electromagnetic.ogg" ).set( "electric", "sound/vox_fem/electric.ogg" ).set( "eighty", "sound/vox_fem/eighty.ogg" ).set( "eighteen", "sound/vox_fem/eighteen.ogg" ).set( "eight", "sound/vox_fem/eight.ogg" ).set( "egress", "sound/vox_fem/egress.ogg" ).set( "effect", "sound/vox_fem/effect.ogg" ).set( "ed", "sound/vox_fem/ed.ogg" ).set( "echo", "sound/vox_fem/echo.ogg" ).set( "east", "sound/vox_fem/east.ogg" ).set( "e", "sound/vox_fem/e.ogg" ).set( "duct", "sound/vox_fem/duct.ogg" ).set( "dual", "sound/vox_fem/dual.ogg" ).set( "down", "sound/vox_fem/down.ogg" ).set( "door", "sound/vox_fem/door.ogg" ).set( "doctor", "sound/vox_fem/doctor.ogg" ).set( "do", "sound/vox_fem/do.ogg" ).set( "distortion", "sound/vox_fem/distortion.ogg" ).set( "distance", "sound/vox_fem/distance.ogg" ).set( "disposal", "sound/vox_fem/disposal.ogg" ).set( "dish", "sound/vox_fem/dish.ogg" ).set( "disengaged", "sound/vox_fem/disengaged.ogg" ).set( "dirt", "sound/vox_fem/dirt.ogg" ).set( "dimensional", "sound/vox_fem/dimensional.ogg" ).set( "die", "sound/vox_fem/die.ogg" ).set( "did", "sound/vox_fem/did.ogg" ).set( "device", "sound/vox_fem/device.ogg" ).set( "detonation", "sound/vox_fem/detonation.ogg" ).set( "detected", "sound/vox_fem/detected.ogg" ).set( "detain", "sound/vox_fem/detain.ogg" ).set( "destroyed", "sound/vox_fem/destroyed.ogg" ).set( "destroy", "sound/vox_fem/destroy.ogg" ).set( "deployed", "sound/vox_fem/deployed.ogg" ).set( "deploy", "sound/vox_fem/deploy.ogg" ).set( "denied", "sound/vox_fem/denied.ogg" ).set( "delta", "sound/vox_fem/delta.ogg" ).set( "degrees", "sound/vox_fem/degrees.ogg" ).set( "defense", "sound/vox_fem/defense.ogg" ).set( "deeoo", "sound/vox_fem/deeoo.ogg" ).set( "decontamination", "sound/vox_fem/decontamination.ogg" ).set( "decompression", "sound/vox_fem/decompression.ogg" ).set( "deactivated", "sound/vox_fem/deactivated.ogg" ).set( "day", "sound/vox_fem/day.ogg" ).set( "danger", "sound/vox_fem/danger.ogg" ).set( "damaged", "sound/vox_fem/damaged.ogg" ).set( "damage", "sound/vox_fem/damage.ogg" ).set( "d", "sound/vox_fem/d.ogg" ).set( "cyborgs", "sound/vox_fem/cyborgs.ogg" ).set( "cyborg", "sound/vox_fem/cyborg.ogg" ).set( "cunt", "sound/vox_fem/cunt.ogg" ).set( "cryogenic", "sound/vox_fem/cryogenic.ogg" ).set( "cross", "sound/vox_fem/cross.ogg" ).set( "crew", "sound/vox_fem/crew.ogg" ).set( "cowards", "sound/vox_fem/cowards.ogg" ).set( "coward", "sound/vox_fem/coward.ogg" ).set( "corridor", "sound/vox_fem/corridor.ogg" ).set( "correct", "sound/vox_fem/correct.ogg" ).set( "core", "sound/vox_fem/core.ogg" ).set( "coomer", "sound/vox_fem/coomer.ogg" ).set( "coolant", "sound/vox_fem/coolant.ogg" ).set( "control", "sound/vox_fem/control.ogg" ).set( "contraband", "sound/vox_fem/contraband.ogg" ).set( "contamination", "sound/vox_fem/contamination.ogg" ).set( "containment", "sound/vox_fem/containment.ogg" ).set( "connor", "sound/vox_fem/connor.ogg" ).set( "condition", "sound/vox_fem/condition.ogg" ).set( "computer", "sound/vox_fem/computer.ogg" ).set( "complex", "sound/vox_fem/complex.ogg" ).set( "communication", "sound/vox_fem/communication.ogg" ).set( "command", "sound/vox_fem/command.ogg" ).set( "come", "sound/vox_fem/come.ogg" ).set( "collider", "sound/vox_fem/collider.ogg" ).set( "coded", "sound/vox_fem/coded.ogg" ).set( "code", "sound/vox_fem/code.ogg" ).set( "clown", "sound/vox_fem/clown.ogg" ).set( "close", "sound/vox_fem/close.ogg" ).set( "clearance", "sound/vox_fem/clearance.ogg" ).set( "clear", "sound/vox_fem/clear.ogg" ).set( "cleanup", "sound/vox_fem/cleanup.ogg" ).set( "chemical", "sound/vox_fem/chemical.ogg" ).set( "checkpoint", "sound/vox_fem/checkpoint.ogg" ).set( "check", "sound/vox_fem/check.ogg" ).set( "charlie", "sound/vox_fem/charlie.ogg" ).set( "changed", "sound/vox_fem/changed.ogg" ).set( "chamber", "sound/vox_fem/chamber.ogg" ).set( "central", "sound/vox_fem/central.ogg" ).set( "centi", "sound/vox_fem/centi.ogg" ).set( "center", "sound/vox_fem/center.ogg" ).set( "centcom", "sound/vox_fem/centcom.ogg" ).set( "celsius", "sound/vox_fem/celsius.ogg" ).set( "ceiling", "sound/vox_fem/ceiling.ogg" ).set( "cargo", "sound/vox_fem/cargo.ogg" ).set( "capture", "sound/vox_fem/capture.ogg" ).set( "captain", "sound/vox_fem/captain.ogg" ).set( "cap", "sound/vox_fem/cap.ogg" ).set( "canal", "sound/vox_fem/canal.ogg" ).set( "called", "sound/vox_fem/called.ogg" ).set( "call", "sound/vox_fem/call.ogg" ).set( "cable", "sound/vox_fem/cable.ogg" ).set( "c", "sound/vox_fem/c.ogg" ).set( "bypass", "sound/vox_fem/bypass.ogg" ).set( "button", "sound/vox_fem/button.ogg" ).set( "but", "sound/vox_fem/but.ogg" ).set( "bust", "sound/vox_fem/bust.ogg" ).set( "bridge", "sound/vox_fem/bridge.ogg" ).set( "break", "sound/vox_fem/break.ogg" ).set( "breached", "sound/vox_fem/breached.ogg" ).set( "breach", "sound/vox_fem/breach.ogg" ).set( "bravo", "sound/vox_fem/bravo.ogg" ).set( "bottom", "sound/vox_fem/bottom.ogg" ).set( "blue", "sound/vox_fem/blue.ogg" ).set( "blocked", "sound/vox_fem/blocked.ogg" ).set( "blast", "sound/vox_fem/blast.ogg" ).set( "black", "sound/vox_fem/black.ogg" ).set( "bitches", "sound/vox_fem/bitches.ogg" ).set( "bitch", "sound/vox_fem/bitch.ogg" ).set( "birdwell", "sound/vox_fem/birdwell.ogg" ).set( "biological", "sound/vox_fem/biological.ogg" ).set( "biohazard", "sound/vox_fem/biohazard.ogg" ).set( "beyond", "sound/vox_fem/beyond.ogg" ).set( "before", "sound/vox_fem/before.ogg" ).set( "been", "sound/vox_fem/been.ogg" ).set( "be", "sound/vox_fem/be.ogg" ).set( "bay", "sound/vox_fem/bay.ogg" ).set( "base", "sound/vox_fem/base.ogg" ).set( "barracks", "sound/vox_fem/barracks.ogg" ).set( "bailey", "sound/vox_fem/bailey.ogg" ).set( "bag", "sound/vox_fem/bag.ogg" ).set( "bad", "sound/vox_fem/bad.ogg" ).set( "backman", "sound/vox_fem/backman.ogg" ).set( "back", "sound/vox_fem/back.ogg" ).set( "b", "sound/vox_fem/b.ogg" ).set( "away", "sound/vox_fem/away.ogg" ).set( "automatic", "sound/vox_fem/automatic.ogg" ).set( "authorized", "sound/vox_fem/authorized.ogg" ).set( "authorize", "sound/vox_fem/authorize.ogg" ).set( "attention", "sound/vox_fem/attention.ogg" ).set( "atomic", "sound/vox_fem/atomic.ogg" ).set( "at", "sound/vox_fem/at.ogg" ).set( "assholes", "sound/vox_fem/assholes.ogg" ).set( "asshole", "sound/vox_fem/asshole.ogg" ).set( "ass", "sound/vox_fem/ass.ogg" ).set( "asimov", "sound/vox_fem/asimov.ogg" ).set( "arrest", "sound/vox_fem/arrest.ogg" ).set( "array", "sound/vox_fem/array.ogg" ).set( "armory", "sound/vox_fem/armory.ogg" ).set( "armor", "sound/vox_fem/armor.ogg" ).set( "armed", "sound/vox_fem/armed.ogg" ).set( "arm", "sound/vox_fem/arm.ogg" ).set( "area", "sound/vox_fem/area.ogg" ).set( "are", "sound/vox_fem/are.ogg" ).set( "approach", "sound/vox_fem/approach.ogg" ).set( "apprehend", "sound/vox_fem/apprehend.ogg" ).set( "any", "sound/vox_fem/any.ogg" ).set( "antenna", "sound/vox_fem/antenna.ogg" ).set( "anomalous", "sound/vox_fem/anomalous.ogg" ).set( "announcement", "sound/vox_fem/announcement.ogg" ).set( "and", "sound/vox_fem/and.ogg" ).set( "an", "sound/vox_fem/an.ogg" ).set( "ammunition", "sound/vox_fem/ammunition.ogg" ).set( "amigo", "sound/vox_fem/amigo.ogg" ).set( "am", "sound/vox_fem/am.ogg" ).set( "alpha", "sound/vox_fem/alpha.ogg" ).set( "all", "sound/vox_fem/all.ogg" ).set( "aligned", "sound/vox_fem/aligned.ogg" ).set( "alien", "sound/vox_fem/alien.ogg" ).set( "alert", "sound/vox_fem/alert.ogg" ).set( "alarm", "sound/vox_fem/alarm.ogg" ).set( "ai", "sound/vox_fem/ai.ogg" ).set( "agent", "sound/vox_fem/agent.ogg" ).set( "after", "sound/vox_fem/after.ogg" ).set( "aft", "sound/vox_fem/aft.ogg" ).set( "advanced", "sound/vox_fem/advanced.ogg" ).set( "administration", "sound/vox_fem/administration.ogg" ).set( "adios", "sound/vox_fem/adios.ogg" ).set( "activity", "sound/vox_fem/activity.ogg" ).set( "activated", "sound/vox_fem/activated.ogg" ).set( "activate", "sound/vox_fem/activate.ogg" ).set( "across", "sound/vox_fem/across.ogg" ).set( "acquisition", "sound/vox_fem/acquisition.ogg" ).set( "acquired", "sound/vox_fem/acquired.ogg" ).set( "acknowledged", "sound/vox_fem/acknowledged.ogg" ).set( "acknowledge", "sound/vox_fem/acknowledge.ogg" ).set( "access", "sound/vox_fem/access.ogg" ).set( "accepted", "sound/vox_fem/accepted.ogg" ).set( "accelerator", "sound/vox_fem/accelerator.ogg" ).set( "accelerating", "sound/vox_fem/accelerating.ogg" ).set( "abortions", "sound/vox_fem/abortions.ogg" ).set( "a", "sound/vox_fem/a.ogg" ).set( ".", "sound/vox_fem/..ogg" ).set( ",", "sound/vox_fem/,.ogg" );
		public static readonly ByTable VVckey_edit = new ByTable(new object [] { "key", "ckey" });
		public static readonly ByTable VVicon_edit_lock = new ByTable(new object [] { "icon", "icon_state", "overlays", "underlays", "resize" });
		public static readonly ByTable VVlocked = new ByTable(new object [] { "vars", "client", "virus", "viruses", "cuffed", "last_eaten", "unlock_content", "step_x", "step_y", "force_ending" });
		public static readonly int waittime_h = 1800;
		public static readonly int waittime_l = 600;
		public static readonly ByTable WALLITEMS = new ByTable(new object [] { typeof(Ent_Machinery_Power_Apc), typeof(Ent_Machinery_Alarm), typeof(Ent_Item_Device_Radio_Intercom), typeof(Ent_Structure_ExtinguisherCabinet), typeof(Ent_Structure_ReagentDispensers_Peppertank), typeof(Ent_Machinery_StatusDisplay), typeof(Ent_Machinery_RequestsConsole), typeof(Ent_Machinery_LightSwitch), typeof(Ent_Structure_Sign), typeof(Ent_Machinery_Newscaster), typeof(Ent_Machinery_Firealarm), typeof(Ent_Structure_Noticeboard), typeof(Ent_Machinery_Button), typeof(Ent_Machinery_Computer_Security_Telescreen), typeof(Ent_Machinery_EmbeddedController_Radio_SimpleVentController), typeof(Ent_Item_Weapon_Storage_Secure_Safe), typeof(Ent_Machinery_DoorTimer), typeof(Ent_Machinery_Flasher), typeof(Ent_Machinery_KeycardAuth), typeof(Ent_Structure_Mirror), typeof(Ent_Structure_Fireaxecabinet), typeof(Ent_Machinery_Computer_Security_Telescreen_Entertainment) });
		public static readonly ByTable WALLITEMS_EXTERNAL = new ByTable(new object [] { typeof(Ent_Machinery_Camera), typeof(Ent_Machinery_CameraAssembly), typeof(Ent_Machinery_LightConstruct), typeof(Ent_Machinery_Light) });
		public static readonly ByTable WALLITEMS_INVERSE = new ByTable(new object [] { typeof(Ent_Machinery_LightConstruct), typeof(Ent_Machinery_Light) });
		public static ByTable weedImageCache = null;
		public static readonly int WEST = 8;
		public static readonly int WIRE_ACTIVATE = 16;
		public static readonly int WIRE_BOOM = 1;
		public static readonly int WIRE_DELAY = 4;
		public static readonly int WIRE_PROCEED = 8;
		public static readonly int WIRE_RECEIVE = 2;
		public static readonly int WIRE_TRANSMIT = 4;
		public static readonly int WIRE_UNBOLT = 2;
		public static readonly ByTable wireColours = new ByTable(new object [] { "red", "blue", "green", "black", "orange", "brown", "gold", "gray", "cyan", "navy", "purple", "pink" });
		public static readonly dynamic wizard_first = GlobalFuncs.file2list( "config/names/wizardfirst.txt" );
		public static readonly dynamic wizard_second = GlobalFuncs.file2list( "config/names/wizardsecond.txt" );
		public static ByTable wizardstart = new ByTable();
		public static readonly ByTable wood_recipes = new ByTable(new object [] { new StackRecipe( "wooden sandals", typeof(Ent_Item_Clothing_Shoes_Sandal), 1 ), new StackRecipe( "wood floor tile", typeof(Ent_Item_Stack_Tile_Wood), 1, 4, 20 ), new ByTable().set( "time", 10 ).set( 3, 2 ).set( 2, typeof(Ent_Structure_TableFrame_Wood) ).set( 1, "wood table frame" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "time", 40 ).set( 3, 10 ).set( 2, typeof(Ent_Item_Weaponcrafting_Stock) ).set( 1, "rifle stock" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 10 ).set( 3, 3 ).set( 2, typeof(Ent_Structure_Bed_Chair_Wood_Normal) ).set( 1, "wooden chair" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 50 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Barricade_Wooden) ).set( 1, "wooden barricade" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 20 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_MineralDoor_Wood) ).set( 1, "wooden door" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 15 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_Closet_Coffin) ).set( 1, "coffin" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 15 ).set( 3, 4 ).set( 2, typeof(Ent_Structure_Bookcase) ).set( 1, "book case" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 15 ).set( 3, 10 ).set( 2, typeof(Ent_Machinery_Smartfridge_DryingRack) ).set( 1, "drying rack" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( "time", 10 ).set( 3, 10 ).set( 2, typeof(Ent_Structure_Bed_Dogbed) ).set( 1, "dog bed" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( "one_per_turf", 1 ).set( 3, 5 ).set( 2, typeof(Ent_Structure_DisplaycaseChassis) ).set( 1, "display case chassis" ).applyCtor( typeof(StackRecipe) ) });
		public static ByTable world_uplinks = new ByTable();
		public static readonly ByTable xeno_recipes = new ByTable(new object [] { new ByTable().set( "on_floor", 1 ).set( 3, 1 ).set( 2, typeof(Ent_Item_Clothing_Head_Xenos) ).set( 1, "alien helmet" ).applyCtor( typeof(StackRecipe) ), new ByTable().set( "on_floor", 1 ).set( 3, 2 ).set( 2, typeof(Ent_Item_Clothing_Suit_Xenos) ).set( 1, "alien suit" ).applyCtor( typeof(StackRecipe) ) });
		public static ByTable xeno_spawn = new ByTable();
		public static readonly dynamic year = Misc13.formatTime( Game.realtime, "YYYY" );
		public static readonly dynamic year_integer = Misc13.parseNumber( GlobalVars.year );
		public static readonly ByTable z_levels_list = new ByTable();
		public static readonly ByTable zero_character_only = new ByTable(new object [] { "0" });
	}
}