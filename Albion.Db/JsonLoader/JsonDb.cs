using System;
using System.Globalization;
using System.IO;
using Albion.Db.Items;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Albion.Db.JsonLoader
{
    public partial class JsonDb
    {
        public static JsonDb Load()
        {
            using (StreamReader file = File.OpenText(@"items.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                foreach (var converter in Converter.Settings.Converters)
                {
                    serializer.Converters.Add(converter);
                }

                using (JsonReader reader = new JsonTextReader(file))
                {
                    JsonDb jsonDb = serializer.Deserialize<JsonDb>(reader);
                    return jsonDb;
                }
            }
        }

        [JsonProperty("items")]
        public Items Items { get; set; }
    }

        public class Items
        {
            [JsonProperty("@xmlns:xsi")]
            public Uri XmlnsXsi { get; set; }

            [JsonProperty("@xsi:noNamespaceSchemaLocation")]
            public string XsiNoNamespaceSchemaLocation { get; set; }

            [JsonProperty("farmableitem")]
            public Farmableitem[] Farmableitem { get; set; }

            [JsonProperty("simpleitem")]
            public Simpleitem[] Simpleitem { get; set; }

            [JsonProperty("consumableitem")]
            public Consumableitem[] Consumableitem { get; set; }

            [JsonProperty("consumablefrominventoryitem")]
            public Consumablefrominventoryitem[] Consumablefrominventoryitem { get; set; }

            [JsonProperty("equipmentitem")]
            public Equipmentitem[] Equipmentitem { get; set; }

            [JsonProperty("weapon")]
            public Weapon[] Weapon { get; set; }

            [JsonProperty("mount")]
            public Mount[] Mount { get; set; }

            [JsonProperty("furnitureitem")]
            public Furnitureitem[] Furnitureitem { get; set; }

            [JsonProperty("journalitem")]
            public Journalitem[] Journalitem { get; set; }
        }

        public class Consumablefrominventoryitem
        {
            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }

            [JsonProperty("@tradable", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Tradable { get; set; }

            [JsonProperty("@uisprite", NullValueHandling = NullValueHandling.Ignore)]
            public string Uisprite { get; set; }

            [JsonProperty("@abilitypower")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Abilitypower { get; set; }

            [JsonProperty("@consumespell")]
            public string Consumespell { get; set; }

            [JsonProperty("@shopcategory")]
            public ConsumablefrominventoryitemShopcategory Shopcategory { get; set; }

            [JsonProperty("@shopsubcategory1")]
            public ConsumablefrominventoryitemShopsubcategory1 Shopsubcategory1 { get; set; }

            [JsonProperty("@tier")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Tier { get; set; }

            [JsonProperty("@weight")]
            public string Weight { get; set; }

            [JsonProperty("@dummyitempower", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Dummyitempower { get; set; }

            [JsonProperty("@maxstacksize", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Maxstacksize { get; set; }

            [JsonProperty("@unlockedtocraft")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Unlockedtocraft { get; set; }

            [JsonProperty("@uicraftsoundstart", NullValueHandling = NullValueHandling.Ignore)]
            public ConsumablefrominventoryitemUicraftsoundstart? Uicraftsoundstart { get; set; }

            [JsonProperty("@uicraftsoundfinish", NullValueHandling = NullValueHandling.Ignore)]
            public ConsumablefrominventoryitemUicraftsoundfinish? Uicraftsoundfinish { get; set; }

            [JsonProperty("@itemvalue", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Itemvalue { get; set; }

            [JsonProperty("@uispriteoverlay", NullValueHandling = NullValueHandling.Ignore)]
            public Uispriteoverlay? Uispriteoverlay { get; set; }

            [JsonProperty("@enchantmentlevel", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Enchantmentlevel { get; set; }

            [JsonProperty("@descriptionlocatag", NullValueHandling = NullValueHandling.Ignore)]
            public ConsumablefrominventoryitemDescriptionlocatag? Descriptionlocatag { get; set; }

            [JsonProperty("@salvageable", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Salvageable { get; set; }

            [JsonProperty("craftingrequirements", NullValueHandling = NullValueHandling.Ignore)]
            public Craftingrequirements Craftingrequirements { get; set; }

            [JsonProperty("@showinmarketplace", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Showinmarketplace { get; set; }

            [JsonProperty("AudioInfo", NullValueHandling = NullValueHandling.Ignore)]
            public AudioInfo AudioInfo { get; set; }
        }

        public class AudioInfo
        {
            [JsonProperty("@name")]
            public string Name { get; set; }
        }

        public class CraftresourceElement
        {
            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }

            [JsonProperty("@count")]
            public int Count { get; set; }

            [JsonProperty("@maxreturnamount", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Maxreturnamount { get; set; }

            [JsonProperty("@enchantmentlevel", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Enchantmentlevel { get; set; }
        }

        public class Consumableitem
        {
            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }

            [JsonProperty("@fishingfame", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Fishingfame { get; set; }

            [JsonProperty("@fishingminigamesetting", NullValueHandling = NullValueHandling.Ignore)]
            public string Fishingminigamesetting { get; set; }

            [JsonProperty("@descriptionlocatag", NullValueHandling = NullValueHandling.Ignore)]
            public string Descriptionlocatag { get; set; }

            [JsonProperty("@uisprite", NullValueHandling = NullValueHandling.Ignore)]
            public string Uisprite { get; set; }

            [JsonProperty("@nutrition", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Nutrition { get; set; }

            [JsonProperty("@abilitypower")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Abilitypower { get; set; }

            [JsonProperty("@slottype")]
            public ConsumableitemSlottype Slottype { get; set; }

            [JsonProperty("@consumespell")]
            public string Consumespell { get; set; }

            [JsonProperty("@shopcategory")]
            public ConsumablefrominventoryitemShopcategory Shopcategory { get; set; }

            [JsonProperty("@shopsubcategory1")]
            public ConsumableitemShopsubcategory1 Shopsubcategory1 { get; set; }

            [JsonProperty("@resourcetype", NullValueHandling = NullValueHandling.Ignore)]
            public ConsumableitemResourcetype? Resourcetype { get; set; }

            [JsonProperty("@tier")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Tier { get; set; }

            [JsonProperty("@weight", NullValueHandling = NullValueHandling.Ignore)]
            public string Weight { get; set; }

            [JsonProperty("@dummyitempower", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Dummyitempower { get; set; }

            [JsonProperty("@maxstacksize", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Maxstacksize { get; set; }

            [JsonProperty("@unlockedtocraft")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Unlockedtocraft { get; set; }

            [JsonProperty("@unlockedtoequip")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Unlockedtoequip { get; set; }

            [JsonProperty("@uicraftsoundstart", NullValueHandling = NullValueHandling.Ignore)]
            public ConsumablefrominventoryitemUicraftsoundstart? Uicraftsoundstart { get; set; }

            [JsonProperty("@uicraftsoundfinish", NullValueHandling = NullValueHandling.Ignore)]
            public ConsumablefrominventoryitemUicraftsoundfinish? Uicraftsoundfinish { get; set; }

            [JsonProperty("craftingrequirements", NullValueHandling = NullValueHandling.Ignore)]
            public ConsumableitemCraftingrequirements Craftingrequirements { get; set; }

            [JsonProperty("enchantments", NullValueHandling = NullValueHandling.Ignore)]
            public ConsumableitemEnchantments Enchantments { get; set; }

            [JsonProperty("@uispriteoverlay", NullValueHandling = NullValueHandling.Ignore)]
            public Uispriteoverlay? Uispriteoverlay { get; set; }

            [JsonProperty("@tradable", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Tradable { get; set; }
        }

        public class ConsumableitemCraftingrequirements
        {
            [JsonProperty("@silver", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Silver { get; set; }

            [JsonProperty("@time")]
            public string Time { get; set; }

            [JsonProperty("@amountcrafted", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Amountcrafted { get; set; }

            [JsonProperty("@forcesinglecraft", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Forcesinglecraft { get; set; }

            [JsonProperty("@craftingfocus", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Craftingfocus { get; set; }

            [JsonProperty("craftresource", NullValueHandling = NullValueHandling.Ignore)]
            public PurpleCraftresource? Craftresource { get; set; }

            [JsonProperty("@gold", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Gold { get; set; }
        }

        public class Replacementitem
        {
            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }

            [JsonProperty("@count")]
            public int Count { get; set; }
        }

        public class ConsumableitemEnchantments
        {
            [JsonProperty("enchantment")]
            public EnchantmentUnion Enchantment { get; set; }
        }

        public class EnchantmentEnchantment
        {
            [JsonProperty("@enchantmentlevel")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Enchantmentlevel { get; set; }

            [JsonProperty("@abilitypower")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Abilitypower { get; set; }

            [JsonProperty("@dummyitempower")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Dummyitempower { get; set; }

            [JsonProperty("@consumespell")]
            public string Consumespell { get; set; }

            [JsonProperty("@nutrition", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Nutrition { get; set; }

            [JsonProperty("@weight", NullValueHandling = NullValueHandling.Ignore)]
            public string Weight { get; set; }

            [JsonProperty("craftingrequirements")]
            public PurpleCraftingrequirements Craftingrequirements { get; set; }

            [JsonProperty("upgraderequirements")]
            public Upgraderequirements Upgraderequirements { get; set; }
        }

        public class PurpleCraftingrequirements
        {
            [JsonProperty("@time")]
            public string Time { get; set; }

            [JsonProperty("@craftingfocus")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Craftingfocus { get; set; }

            [JsonProperty("@amountcrafted")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Amountcrafted { get; set; }

            [JsonProperty("craftresource")]
            public Replacementitem[] Craftresource { get; set; }
        }

        public class Upgraderequirements
        {
            [JsonProperty("upgraderesource")]
            public Replacementitem Upgraderesource { get; set; }
        }

        public class Equipmentitem
        {
            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }

            [JsonProperty("@uisprite", NullValueHandling = NullValueHandling.Ignore)]
            public string Uisprite { get; set; }

            [JsonProperty("@maxqualitylevel")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Maxqualitylevel { get; set; }

            [JsonProperty("@abilitypower")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Abilitypower { get; set; }

            [JsonProperty("@slottype")]
            public SlottypeEnum Slottype { get; set; }

            [JsonProperty("@itempowerprogressiontype", NullValueHandling = NullValueHandling.Ignore)]
            public Iontype? Itempowerprogressiontype { get; set; }

            [JsonProperty("@shopcategory")]
            public ShopCategory Shopcategory { get; set; }

            [JsonProperty("@shopsubcategory1")]
            public string Shopsubcategory1 { get; set; }

            [JsonProperty("@uicraftsoundstart", NullValueHandling = NullValueHandling.Ignore)]
            public EquipmentitemUicraftsoundstart? Uicraftsoundstart { get; set; }

            [JsonProperty("@uicraftsoundfinish", NullValueHandling = NullValueHandling.Ignore)]
            public EquipmentitemUicraftsoundfinish? Uicraftsoundfinish { get; set; }

            [JsonProperty("@skincount", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Skincount { get; set; }

            [JsonProperty("@tier")]
            public int Tier { get; set; }

            [JsonProperty("@weight")]
            public float Weight { get; set; }

            [JsonProperty("@activespellslots")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Activespellslots { get; set; }

            [JsonProperty("@passivespellslots")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Passivespellslots { get; set; }

            [JsonProperty("@physicalarmor")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Physicalarmor { get; set; }

            [JsonProperty("@magicresistance")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Magicresistance { get; set; }

            [JsonProperty("@durability")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Durability { get; set; }

            [JsonProperty("@durabilityloss_attack")]
            public string DurabilitylossAttack { get; set; }

            [JsonProperty("@durabilityloss_spelluse")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long DurabilitylossSpelluse { get; set; }

            [JsonProperty("@durabilityloss_receivedattack")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long DurabilitylossReceivedattack { get; set; }

            [JsonProperty("@durabilityloss_receivedspell")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long DurabilitylossReceivedspell { get; set; }

            [JsonProperty("@offhandanimationtype", NullValueHandling = NullValueHandling.Ignore)]
            public Iontype? Offhandanimationtype { get; set; }

            [JsonProperty("@unlockedtocraft")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Unlockedtocraft { get; set; }

            [JsonProperty("@unlockedtoequip")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Unlockedtoequip { get; set; }

            [JsonProperty("@hitpointsmax")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Hitpointsmax { get; set; }

            [JsonProperty("@hitpointsregenerationbonus")]
            public string Hitpointsregenerationbonus { get; set; }

            [JsonProperty("@energymax")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Energymax { get; set; }

            [JsonProperty("@energyregenerationbonus")]
            public string Energyregenerationbonus { get; set; }

            [JsonProperty("@crowdcontrolresistance")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Crowdcontrolresistance { get; set; }

            [JsonProperty("@itempower")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Itempower { get; set; }

            [JsonProperty("@physicalattackdamagebonus")]
            public string Physicalattackdamagebonus { get; set; }

            [JsonProperty("@magicattackdamagebonus")]
            public string Magicattackdamagebonus { get; set; }

            [JsonProperty("@physicalspelldamagebonus")]
            public string Physicalspelldamagebonus { get; set; }

            [JsonProperty("@magicspelldamagebonus")]
            public string Magicspelldamagebonus { get; set; }

            [JsonProperty("@healbonus")]
            public string Healbonus { get; set; }

            [JsonProperty("@bonusccdurationvsplayers")]
            public string Bonusccdurationvsplayers { get; set; }

            [JsonProperty("@bonusccdurationvsmobs")]
            public string Bonusccdurationvsmobs { get; set; }

            [JsonProperty("@threatbonus")]
            public string Threatbonus { get; set; }

            [JsonProperty("@magiccooldownreduction")]
            public string Magiccooldownreduction { get; set; }

            [JsonProperty("@bonusdefensevsplayers", NullValueHandling = NullValueHandling.Ignore)]
            public string Bonusdefensevsplayers { get; set; }

            [JsonProperty("@bonusdefensevsmobs", NullValueHandling = NullValueHandling.Ignore)]
            public string Bonusdefensevsmobs { get; set; }

            [JsonProperty("@magiccasttimereduction", NullValueHandling = NullValueHandling.Ignore)]
            public string Magiccasttimereduction { get; set; }

            [JsonProperty("@attackspeedbonus", NullValueHandling = NullValueHandling.Ignore)]
            public string Attackspeedbonus { get; set; }

            [JsonProperty("@movespeedbonus", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Movespeedbonus { get; set; }

            [JsonProperty("@healmodifier", NullValueHandling = NullValueHandling.Ignore)]
            public string Healmodifier { get; set; }

            [JsonProperty("@canbeovercharged", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Canbeovercharged { get; set; }

            [JsonProperty("@showinmarketplace", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Showinmarketplace { get; set; }

            [JsonProperty("@energycostreduction", NullValueHandling = NullValueHandling.Ignore)]
            public string Energycostreduction { get; set; }

            [JsonProperty("craftingrequirements", NullValueHandling = NullValueHandling.Ignore)]
            public Craftingrequirements? Craftingrequirements { get; set; }

            [JsonProperty("@craftingcategory", NullValueHandling = NullValueHandling.Ignore)]
            public Craftingcategory? Craftingcategory { get; set; }

            [JsonProperty("SocketPreset", NullValueHandling = NullValueHandling.Ignore)]
            public AudioInfo SocketPreset { get; set; }

            [JsonProperty("enchantments", NullValueHandling = NullValueHandling.Ignore)]
            public EquipmentitemEnchantments Enchantments { get; set; }

            [JsonProperty("AssetVfxPreset", NullValueHandling = NullValueHandling.Ignore)]
            public AudioInfo AssetVfxPreset { get; set; }

            [JsonProperty("craftingspelllist", NullValueHandling = NullValueHandling.Ignore)]
            public EquipmentitemCraftingspelllist Craftingspelllist { get; set; }

            [JsonProperty("@tradable", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Tradable { get; set; }

            [JsonProperty("@movespeed", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Movespeed { get; set; }

            [JsonProperty("@maxload", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Maxload { get; set; }

            [JsonProperty("@facestate", NullValueHandling = NullValueHandling.Ignore)]
            public Facestate? Facestate { get; set; }

            [JsonProperty("@requiredaccesslevel", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Requiredaccesslevel { get; set; }

            [JsonProperty("@uispriteoverlay", NullValueHandling = NullValueHandling.Ignore)]
            public Uispriteoverlay? Uispriteoverlay { get; set; }

            [JsonProperty("AudioInfo", NullValueHandling = NullValueHandling.Ignore)]
            public AudioInfo AudioInfo { get; set; }

            [JsonProperty("@beardstate", NullValueHandling = NullValueHandling.Ignore)]
            public Beardstate? Beardstate { get; set; }

            [JsonProperty("@mesh", NullValueHandling = NullValueHandling.Ignore)]
            public string Mesh { get; set; }

            [JsonProperty("@craftfamegainfactor", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Craftfamegainfactor { get; set; }

            [JsonProperty("@enchantmentlevel", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Enchantmentlevel { get; set; }

            [JsonProperty("@mainhandanimationtype", NullValueHandling = NullValueHandling.Ignore)]
            public string Mainhandanimationtype { get; set; }

            [JsonProperty("@descriptionlocatag", NullValueHandling = NullValueHandling.Ignore)]
            public EquipmentitemDescriptionlocatag? Descriptionlocatag { get; set; }
        }

        public class EquipmentitemCraftingspelllist
        {
            [JsonProperty("craftspell")]
            public TentacledCraftspell Craftspell { get; set; }
        }

        public class PurpleCraftspell
        {
            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }

            [JsonProperty("@slots", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Slots { get; set; }
        }

        public class CraftingspelllistCraftspellClass
        {
            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }
        }

        public class EquipmentitemEnchantments
        {
            [JsonProperty("enchantment")]
            public PurpleEnchantment[] Enchantment { get; set; }
        }

        public class PurpleEnchantment
        {
            [JsonProperty("@enchantmentlevel")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Enchantmentlevel { get; set; }

            [JsonProperty("@itempower")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Itempower { get; set; }

            [JsonProperty("@durability")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Durability { get; set; }

            [JsonProperty("craftingrequirements")]
            public Craftingrequirements Craftingrequirements { get; set; }

            [JsonProperty("upgraderequirements", NullValueHandling = NullValueHandling.Ignore)]
            public Upgraderequirements Upgraderequirements { get; set; }
        }

        public class Farmableitem
        {
            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }

            [JsonProperty("@tier")]
            public int Tier { get; set; }

            [JsonProperty("@craftfamegainfactor", NullValueHandling = NullValueHandling.Ignore)]
            public string Craftfamegainfactor { get; set; }

            [JsonProperty("@placecost")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Placecost { get; set; }

            [JsonProperty("@placefame")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Placefame { get; set; }

            [JsonProperty("@pickupable")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Pickupable { get; set; }

            [JsonProperty("@destroyable")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Destroyable { get; set; }

            [JsonProperty("@unlockedtoplace")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Unlockedtoplace { get; set; }

            [JsonProperty("@maxstacksize")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Maxstacksize { get; set; }

            [JsonProperty("@shopcategory")]
            public ShopCategory Shopcategory { get; set; }

            [JsonProperty("@shopsubcategory1")]
            public FarmableitemShopsubcategory1 Shopsubcategory1 { get; set; }

            [JsonProperty("@kind")]
            public Kind Kind { get; set; }

            [JsonProperty("@weight")]
            public float Weight { get; set; }

            [JsonProperty("@unlockedtocraft")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Unlockedtocraft { get; set; }

            [JsonProperty("@animationid")]
            public Animationid Animationid { get; set; }

            [JsonProperty("@activefarmfocuscost", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Activefarmfocuscost { get; set; }

            [JsonProperty("@activefarmmaxcycles", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Activefarmmaxcycles { get; set; }

            [JsonProperty("@activefarmactiondurationseconds", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Activefarmactiondurationseconds { get; set; }

            [JsonProperty("@activefarmcyclelengthseconds", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Activefarmcyclelengthseconds { get; set; }

            [JsonProperty("@activefarmbonus", NullValueHandling = NullValueHandling.Ignore)]
            public string Activefarmbonus { get; set; }

            [JsonProperty("craftingrequirements", NullValueHandling = NullValueHandling.Ignore)]
            public Craftingrequirements Craftingrequirements { get; set; }
//            public FarmableitemCraftingrequirements Craftingrequirements { get; set; }

            [JsonProperty("AudioInfo")]
            public AudioInfo AudioInfo { get; set; }

            [JsonProperty("harvest", NullValueHandling = NullValueHandling.Ignore)]
            public Harvest Harvest { get; set; }

            [JsonProperty("@prefabname", NullValueHandling = NullValueHandling.Ignore)]
            public string Prefabname { get; set; }

            [JsonProperty("@prefabscale", NullValueHandling = NullValueHandling.Ignore)]
            public string Prefabscale { get; set; }

            [JsonProperty("@resourcevalue", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Resourcevalue { get; set; }

            [JsonProperty("grownitem", NullValueHandling = NullValueHandling.Ignore)]
            public Grownitem Grownitem { get; set; }

            [JsonProperty("consumption", NullValueHandling = NullValueHandling.Ignore)]
            public Consumption Consumption { get; set; }

            [JsonProperty("@tile", NullValueHandling = NullValueHandling.Ignore)]
            public string Tile { get; set; }

            [JsonProperty("@uisprite", NullValueHandling = NullValueHandling.Ignore)]
            public string Uisprite { get; set; }

            [JsonProperty("@showinmarketplace", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Showinmarketplace { get; set; }

            [JsonProperty("products", NullValueHandling = NullValueHandling.Ignore)]
            public Products Products { get; set; }
        }

        public class Consumption
        {
            [JsonProperty("food")]
            public Food Food { get; set; }
        }

        public class Food
        {
            [JsonProperty("@nutritionmax")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Nutritionmax { get; set; }

            [JsonProperty("@secondspernutrition")]
            public string Secondspernutrition { get; set; }

            [JsonProperty("acceptedfood")]
            public Acceptedfood Acceptedfood { get; set; }
        }

        public class Acceptedfood
        {
            [JsonProperty("@foodcategory")]
            public Foodcategory Foodcategory { get; set; }
        }

        public class FarmableitemCraftingrequirements
        {
            [JsonProperty("@silver", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Silver { get; set; }

            [JsonProperty("@time")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Time { get; set; }

            [JsonProperty("@swaptransaction")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Swaptransaction { get; set; }

            [JsonProperty("playerfactionstanding", NullValueHandling = NullValueHandling.Ignore)]
            public Playerfactionstanding Playerfactionstanding { get; set; }

            [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
            public Currency Currency { get; set; }
        }

        public class Currency
        {
            [JsonProperty("@uniquename")]
            public Uniquename Uniquename { get; set; }

            [JsonProperty("@amount")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Amount { get; set; }
        }

        public class Playerfactionstanding
        {
            [JsonProperty("@faction")]
            public Faction Faction { get; set; }

            [JsonProperty("@minstanding")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Minstanding { get; set; }
        }

        public class Grownitem
        {
            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }

            [JsonProperty("@growtime")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Growtime { get; set; }

            [JsonProperty("@fame")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Fame { get; set; }

            [JsonProperty("offspring")]
            public Offspring Offspring { get; set; }
        }

        public class Offspring
        {
            [JsonProperty("@chance")]
            public string Chance { get; set; }

            [JsonProperty("@amount")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Amount { get; set; }
        }

        public class Harvest
        {
            [JsonProperty("@growtime")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Growtime { get; set; }

            [JsonProperty("@lootlist")]
            public string Lootlist { get; set; }

            [JsonProperty("@lootchance")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Lootchance { get; set; }

            [JsonProperty("@fame")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Fame { get; set; }

            [JsonProperty("seed")]
            public Offspring Seed { get; set; }
        }

        public class Products
        {
            [JsonProperty("product")]
            public Product Product { get; set; }
        }

        public class Product
        {
            [JsonProperty("@productiontime")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Productiontime { get; set; }

            [JsonProperty("@actionname")]
            public string Actionname { get; set; }

            [JsonProperty("@lootlist")]
            public string Lootlist { get; set; }

            [JsonProperty("@lootchance")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Lootchance { get; set; }

            [JsonProperty("@fame")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Fame { get; set; }
        }

        public class Furnitureitem
        {
            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }

            [JsonProperty("@shopcategory")]
            public FurnitureitemShopcategory Shopcategory { get; set; }

            [JsonProperty("@shopsubcategory1")]
            public string Shopsubcategory1 { get; set; }

            [JsonProperty("@tier")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Tier { get; set; }

            [JsonProperty("@durability", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Durability { get; set; }

            [JsonProperty("@durabilitylossperdayfactor", NullValueHandling = NullValueHandling.Ignore)]
            public string Durabilitylossperdayfactor { get; set; }

            [JsonProperty("@weight")]
            public string Weight { get; set; }

            [JsonProperty("@unlockedtocraft", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Unlockedtocraft { get; set; }

            [JsonProperty("@placeableindoors")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Placeableindoors { get; set; }

            [JsonProperty("@placeableoutdoors")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Placeableoutdoors { get; set; }

            [JsonProperty("@placeableindungeons")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Placeableindungeons { get; set; }

            [JsonProperty("@accessrightspreset", NullValueHandling = NullValueHandling.Ignore)]
            public string Accessrightspreset { get; set; }

            [JsonProperty("@uicraftsoundstart", NullValueHandling = NullValueHandling.Ignore)]
            public FurnitureitemUicraftsoundstart? Uicraftsoundstart { get; set; }

            [JsonProperty("@uicraftsoundfinish", NullValueHandling = NullValueHandling.Ignore)]
            public FurnitureitemUicraftsoundfinish? Uicraftsoundfinish { get; set; }

            [JsonProperty("craftingrequirements", NullValueHandling = NullValueHandling.Ignore)]
            public ConsumableitemCraftingrequirements Craftingrequirements { get; set; }

            [JsonProperty("repairkit", NullValueHandling = NullValueHandling.Ignore)]
            public Repairkit Repairkit { get; set; }

            [JsonProperty("@customizewithguildlogo", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Customizewithguildlogo { get; set; }

            [JsonProperty("@enchantmentlevel", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Enchantmentlevel { get; set; }

            [JsonProperty("@uisprite", NullValueHandling = NullValueHandling.Ignore)]
            public string Uisprite { get; set; }

            [JsonProperty("@tile", NullValueHandling = NullValueHandling.Ignore)]
            public string Tile { get; set; }

            [JsonProperty("@itemvalue", NullValueHandling = NullValueHandling.Ignore)]
            public string Itemvalue { get; set; }

            [JsonProperty("container", NullValueHandling = NullValueHandling.Ignore)]
            public Container Container { get; set; }

            [JsonProperty("@showinmarketplace", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Showinmarketplace { get; set; }

            [JsonProperty("@residencyslots", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Residencyslots { get; set; }

            [JsonProperty("@labourerfurnituretype", NullValueHandling = NullValueHandling.Ignore)]
            public Labourerfurnituretype? Labourerfurnituretype { get; set; }

            [JsonProperty("@labourersaffected", NullValueHandling = NullValueHandling.Ignore)]
            public Labourersaffected? Labourersaffected { get; set; }

            [JsonProperty("@labourerhappiness", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Labourerhappiness { get; set; }

            [JsonProperty("@labourersperfurnitureitem", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Labourersperfurnitureitem { get; set; }

            [JsonProperty("@placeableonlyonislands", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Placeableonlyonislands { get; set; }

            [JsonProperty("@descriptionlocatag", NullValueHandling = NullValueHandling.Ignore)]
            public FurnitureitemDescriptionlocatag? Descriptionlocatag { get; set; }

            [JsonProperty("@craftfamegainfactor", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Craftfamegainfactor { get; set; }

            [JsonProperty("cheatprovider")]
            public object Cheatprovider { get; set; }

            [JsonProperty("@durabilitylossperusefactor", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Durabilitylossperusefactor { get; set; }
        }

        public class Container
        {
            [JsonProperty("@capacity")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Capacity { get; set; }

            [JsonProperty("@weightlimit")]
            public string Weightlimit { get; set; }
        }

        public class Repairkit
        {
            [JsonProperty("@repaircostfactor")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Repaircostfactor { get; set; }

            [JsonProperty("@maxtier")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Maxtier { get; set; }
        }

        public class Journalitem
        {
            [JsonProperty("@salvageable")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Salvageable { get; set; }

            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }

            [JsonProperty("@tier")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Tier { get; set; }

            [JsonProperty("@maxfame")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Maxfame { get; set; }

            [JsonProperty("@baselootamount")]
            public string Baselootamount { get; set; }

            [JsonProperty("@shopcategory")]
            public FarmableitemShopcategory Shopcategory { get; set; }

            [JsonProperty("@shopsubcategory1")]
            public JournalitemShopsubcategory1 Shopsubcategory1 { get; set; }

            [JsonProperty("@weight")]
            public string Weight { get; set; }

            [JsonProperty("@unlockedtocraft")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Unlockedtocraft { get; set; }

            [JsonProperty("@craftfamegainfactor")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Craftfamegainfactor { get; set; }

            [JsonProperty("@fasttravelfactor", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Fasttravelfactor { get; set; }

            [JsonProperty("craftingrequirements")]
            public JournalitemCraftingrequirements Craftingrequirements { get; set; }

            [JsonProperty("famefillingmissions")]
            public Famefillingmissions Famefillingmissions { get; set; }

            [JsonProperty("lootlist")]
            public Lootlist Lootlist { get; set; }

            [JsonProperty("@uisprite", NullValueHandling = NullValueHandling.Ignore)]
            public string Uisprite { get; set; }
        }

        public class JournalitemCraftingrequirements
        {
            [JsonProperty("@silver")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Silver { get; set; }

            [JsonProperty("@time")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Time { get; set; }

            [JsonProperty("@swaptransaction")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Swaptransaction { get; set; }
        }

        public class Famefillingmissions
        {
            [JsonProperty("gatherfame", NullValueHandling = NullValueHandling.Ignore)]
            public Gatherfame Gatherfame { get; set; }

            [JsonProperty("craftitemfame", NullValueHandling = NullValueHandling.Ignore)]
            public Craftitemfame Craftitemfame { get; set; }

            [JsonProperty("killmobfame", NullValueHandling = NullValueHandling.Ignore)]
            public Killmobfame Killmobfame { get; set; }

            [JsonProperty("fameearned", NullValueHandling = NullValueHandling.Ignore)]
            public Fameearned Fameearned { get; set; }

            [JsonProperty("fishingfame", NullValueHandling = NullValueHandling.Ignore)]
            public Fameearned Fishingfame { get; set; }
        }

        public class Craftitemfame
        {
            [JsonProperty("@mintier")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Mintier { get; set; }

            [JsonProperty("@value")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Value { get; set; }

            [JsonProperty("validitem")]
            public ValiditemElement[] Validitem { get; set; }
        }

        public class ValiditemElement
        {
            [JsonProperty("@id")]
            public string Id { get; set; }
        }

        public class Fameearned
        {
            [JsonProperty("@value")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Value { get; set; }
        }

        public class Gatherfame
        {
            [JsonProperty("@mintier")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Mintier { get; set; }

            [JsonProperty("@value")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Value { get; set; }

            [JsonProperty("validitem")]
            public ValiditemUnion Validitem { get; set; }
        }

        public class Killmobfame
        {
            [JsonProperty("@mintier")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Mintier { get; set; }

            [JsonProperty("@value")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Value { get; set; }
        }

        public class Lootlist
        {
            [JsonProperty("loot")]
            public LootUnion Loot { get; set; }
        }

        public class LootElement
        {
            [JsonProperty("@itemname", NullValueHandling = NullValueHandling.Ignore)]
            public string Itemname { get; set; }

            [JsonProperty("@itemamount", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Itemamount { get; set; }

            [JsonProperty("@weight")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Weight { get; set; }

            [JsonProperty("@labourerfame")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Labourerfame { get; set; }

            [JsonProperty("@itemenchantmentlevel", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Itemenchantmentlevel { get; set; }

            [JsonProperty("@silveramount", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Silveramount { get; set; }
        }

        public class Mount
        {
            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }

            [JsonProperty("@mountcategory", NullValueHandling = NullValueHandling.Ignore)]
            public string Mountcategory { get; set; }

            [JsonProperty("@maxqualitylevel")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Maxqualitylevel { get; set; }

            [JsonProperty("@itempower")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Itempower { get; set; }

            [JsonProperty("@abilitypower")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Abilitypower { get; set; }

            [JsonProperty("@slottype")]
            public MountSlottype Slottype { get; set; }

            [JsonProperty("@shopcategory")]
            public MountShopcategory Shopcategory { get; set; }

            [JsonProperty("@shopsubcategory1")]
            public MountShopsubcategory1 Shopsubcategory1 { get; set; }

            [JsonProperty("@mountedbuff")]
            public string Mountedbuff { get; set; }

            [JsonProperty("@halfmountedbuff")]
            public string Halfmountedbuff { get; set; }

            [JsonProperty("@tier")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Tier { get; set; }

            [JsonProperty("@weight")]
            public string Weight { get; set; }

            [JsonProperty("@activespellslots")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Activespellslots { get; set; }

            [JsonProperty("@passivespellslots")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Passivespellslots { get; set; }

            [JsonProperty("@durability")]
            public string Durability { get; set; }

            [JsonProperty("@durabilityloss_attack")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long DurabilitylossAttack { get; set; }

            [JsonProperty("@durabilityloss_spelluse")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long DurabilitylossSpelluse { get; set; }

            [JsonProperty("@durabilityloss_receivedattack")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long DurabilitylossReceivedattack { get; set; }

            [JsonProperty("@durabilityloss_receivedspell")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long DurabilitylossReceivedspell { get; set; }

            [JsonProperty("@durabilityloss_receivedattack_mounted")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long DurabilitylossReceivedattackMounted { get; set; }

            [JsonProperty("@durabilityloss_receivedspell_mounted")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long DurabilitylossReceivedspellMounted { get; set; }

            [JsonProperty("@durabilityloss_mounting")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long DurabilitylossMounting { get; set; }

            [JsonProperty("@unlockedtocraft")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Unlockedtocraft { get; set; }

            [JsonProperty("@unlockedtoequip")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Unlockedtoequip { get; set; }

            [JsonProperty("@mounttime")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Mounttime { get; set; }

            [JsonProperty("@dismounttime")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Dismounttime { get; set; }

            [JsonProperty("@mounthitpointsmax")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Mounthitpointsmax { get; set; }

            [JsonProperty("@mounthitpointsregeneration")]
            public string Mounthitpointsregeneration { get; set; }

            [JsonProperty("@prefabname")]
            public string Prefabname { get; set; }

            [JsonProperty("@prefabscaling")]
            public string Prefabscaling { get; set; }

            [JsonProperty("@despawneffect")]
            public Despawneffect Despawneffect { get; set; }

            [JsonProperty("@despawneffectscaling")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Despawneffectscaling { get; set; }

            [JsonProperty("@remountdistance")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Remountdistance { get; set; }

            [JsonProperty("@halfmountrange")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Halfmountrange { get; set; }

            [JsonProperty("@forceddismountcooldown")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Forceddismountcooldown { get; set; }

            [JsonProperty("@forceddismountspellcooldown")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Forceddismountspellcooldown { get; set; }

            [JsonProperty("@fulldismountcooldown")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Fulldismountcooldown { get; set; }

            [JsonProperty("@remounttime")]
            public string Remounttime { get; set; }

            [JsonProperty("@uicraftsoundstart")]
            public MountUicraftsoundstart Uicraftsoundstart { get; set; }

            [JsonProperty("@uicraftsoundfinish")]
            public MountUicraftsoundfinish Uicraftsoundfinish { get; set; }

            [JsonProperty("@dismountbuff")]
            public Dismountbuff Dismountbuff { get; set; }

            [JsonProperty("craftingrequirements")]
            public MountCraftingrequirements Craftingrequirements { get; set; }

            [JsonProperty("SocketPreset")]
            public AudioInfo SocketPreset { get; set; }

            [JsonProperty("AudioInfo")]
            public AudioInfo AudioInfo { get; set; }

            [JsonProperty("FootStepVfxPreset", NullValueHandling = NullValueHandling.Ignore)]
            public AudioInfo FootStepVfxPreset { get; set; }

            [JsonProperty("@uisprite", NullValueHandling = NullValueHandling.Ignore)]
            public string Uisprite { get; set; }

            [JsonProperty("@showinmarketplace", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Showinmarketplace { get; set; }

            [JsonProperty("@enchantmentlevel", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Enchantmentlevel { get; set; }

            [JsonProperty("@canuseingvg", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Canuseingvg { get; set; }

            [JsonProperty("AssetVfxPreset", NullValueHandling = NullValueHandling.Ignore)]
            public AudioInfo AssetVfxPreset { get; set; }

            [JsonProperty("mountspelllist", NullValueHandling = NullValueHandling.Ignore)]
            public Mountspelllist Mountspelllist { get; set; }

            [JsonProperty("@itemvalue", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Itemvalue { get; set; }

            [JsonProperty("craftingspelllist", NullValueHandling = NullValueHandling.Ignore)]
            public MountCraftingspelllist Craftingspelllist { get; set; }

            [JsonProperty("@nametagoffset", NullValueHandling = NullValueHandling.Ignore)]
            public string Nametagoffset { get; set; }

            [JsonProperty("@craftfamegainfactor", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Craftfamegainfactor { get; set; }
        }

        public class MountCraftingrequirements
        {
            [JsonProperty("@silver")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Silver { get; set; }

            [JsonProperty("@time")]
            public string Time { get; set; }

            [JsonProperty("@craftingfocus", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Craftingfocus { get; set; }

            [JsonProperty("craftresource", NullValueHandling = NullValueHandling.Ignore)]
            public FluffyCraftresource? Craftresource { get; set; }

            [JsonProperty("@gold", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Gold { get; set; }

            [JsonProperty("@compensategold", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Compensategold { get; set; }
        }

        public class MountCraftingspelllist
        {
            [JsonProperty("craftspell")]
            public CraftingspelllistCraftspellClass Craftspell { get; set; }
        }

        public class Mountspelllist
        {
            [JsonProperty("mountspell")]
            public MountspellUnion Mountspell { get; set; }
        }

        public class MountspellElement
        {
            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }

            [JsonProperty("@spellslot")]
            public Spellslot Spellslot { get; set; }
        }

        public class Simpleitem
        {
            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }

            [JsonProperty("@tier")]
            public int Tier { get; set; }

            [JsonProperty("@weight", NullValueHandling = NullValueHandling.Ignore)]
            public float Weight { get; set; }

            [JsonProperty("@maxstacksize", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Maxstacksize { get; set; }

            [JsonProperty("@uisprite", NullValueHandling = NullValueHandling.Ignore)]
            public string Uisprite { get; set; }

            [JsonProperty("@shopcategory")]
            public ShopCategory Shopcategory { get; set; }

            [JsonProperty("@shopsubcategory1")]
            public string Shopsubcategory1 { get; set; }

            [JsonProperty("@unlockedtocraft", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Unlockedtocraft { get; set; }

            [JsonProperty("@itemvalue", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Itemvalue { get; set; }

            [JsonProperty("@showinmarketplace", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Showinmarketplace { get; set; }

            [JsonProperty("@nutrition", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Nutrition { get; set; }

            [JsonProperty("@foodcategory", NullValueHandling = NullValueHandling.Ignore)]
            public Foodcategory? Foodcategory { get; set; }

            [JsonProperty("@resourcetype", NullValueHandling = NullValueHandling.Ignore)]
            public string Resourcetype { get; set; }

            [JsonProperty("@craftfamegainfactor", NullValueHandling = NullValueHandling.Ignore)]
            public string Craftfamegainfactor { get; set; }

            [JsonProperty("@enchantmentlevel", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Enchantmentlevel { get; set; }

            [JsonProperty("@fishingfame", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Fishingfame { get; set; }

            [JsonProperty("@fishingminigamesetting", NullValueHandling = NullValueHandling.Ignore)]
            public string Fishingminigamesetting { get; set; }

            [JsonProperty("craftingrequirements", NullValueHandling = NullValueHandling.Ignore)]
            public Craftingrequirements? Craftingrequirements { get; set; }

            [JsonProperty("@descriptionlocatag", NullValueHandling = NullValueHandling.Ignore)]
            public SimpleitemDescriptionlocatag? Descriptionlocatag { get; set; }

            [JsonProperty("@fasttravelfactor", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Fasttravelfactor { get; set; }

            [JsonProperty("@namelocatag", NullValueHandling = NullValueHandling.Ignore)]
            public string Namelocatag { get; set; }

            [JsonProperty("@salvageable", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Salvageable { get; set; }

            [JsonProperty("replaceondeath", NullValueHandling = NullValueHandling.Ignore)]
            public Replaceondeath Replaceondeath { get; set; }

            [JsonProperty("@descvariable0", NullValueHandling = NullValueHandling.Ignore)]
            public string Descvariable0 { get; set; }

            [JsonProperty("@descvariable1", NullValueHandling = NullValueHandling.Ignore)]
            public string Descvariable1 { get; set; }

            [JsonProperty("@uicraftsoundstart", NullValueHandling = NullValueHandling.Ignore)]
            public FurnitureitemUicraftsoundstart? Uicraftsoundstart { get; set; }

            [JsonProperty("@uicraftsoundfinish", NullValueHandling = NullValueHandling.Ignore)]
            public FurnitureitemUicraftsoundfinish? Uicraftsoundfinish { get; set; }

            [JsonProperty("@craftingcategory", NullValueHandling = NullValueHandling.Ignore)]
            public Craftingcategory? Craftingcategory { get; set; }

            [JsonProperty("@canbestoredinbattlevault", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Canbestoredinbattlevault { get; set; }
        }

    public class Craftingrequirement
    {
        [JsonProperty("@gold", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(PurpleParseStringConverter))]
        public long? Gold { get; set; }

        [JsonProperty("@time")] public string Time { get; set; }

        [JsonProperty("@amountcrafted", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(PurpleParseStringConverter))]
        public long? Amountcrafted { get; set; }

        [JsonProperty("craftresource", NullValueHandling = NullValueHandling.Ignore)]
        public CraftingrequirementCraftresourceUnion? Craftresource { get; set; }

        [JsonProperty("@silver", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(PurpleParseStringConverter))]
        public long? Silver { get; set; }

        [JsonProperty("@craftingfocus", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(PurpleParseStringConverter))]
        public long? Craftingfocus { get; set; }

        [JsonProperty("@swaptransaction", NullValueHandling = NullValueHandling.Ignore)]
        [JsonConverter(typeof(FluffyParseStringConverter))]
        public bool? Swaptransaction { get; set; }

        [JsonProperty("@buildingfilter", NullValueHandling = NullValueHandling.Ignore)]
        public Buildingfilter? Buildingfilter { get; set; }

        [JsonProperty("currency", NullValueHandling = NullValueHandling.Ignore)]
        public Currency Currency { get; set; }

        [JsonProperty("playerfactionstanding", NullValueHandling = NullValueHandling.Ignore)]
        public Playerfactionstanding Playerfactionstanding { get; set; }
    }

    public class Replaceondeath
        {
            [JsonProperty("replacementitem")]
            public Replacementitem Replacementitem { get; set; }
        }

        public class Weapon
        {
            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }

            [JsonProperty("@mesh", NullValueHandling = NullValueHandling.Ignore)]
            public string Mesh { get; set; }

            [JsonProperty("@uisprite", NullValueHandling = NullValueHandling.Ignore)]
            public string Uisprite { get; set; }

            [JsonProperty("@maxqualitylevel")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Maxqualitylevel { get; set; }

            [JsonProperty("@abilitypower")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Abilitypower { get; set; }

            [JsonProperty("@slottype")]
            public SlottypeEnum Slottype { get; set; }

            [JsonProperty("@shopcategory")]
            public ShopCategory Shopcategory { get; set; }

            [JsonProperty("@shopsubcategory1")]
            public Shopsubcategory1Enum Shopsubcategory1 { get; set; }

            [JsonProperty("@attacktype")]
            public Attacktype Attacktype { get; set; }

            [JsonProperty("@attackdamage")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Attackdamage { get; set; }

            [JsonProperty("@attackspeed")]
            public string Attackspeed { get; set; }

            [JsonProperty("@attackrange")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Attackrange { get; set; }

            [JsonProperty("@twohanded")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Twohanded { get; set; }

            [JsonProperty("@tier")]
            public int Tier { get; set; }

            [JsonProperty("@weight")]
            public float Weight { get; set; }

            [JsonProperty("@activespellslots")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Activespellslots { get; set; }

            [JsonProperty("@passivespellslots")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Passivespellslots { get; set; }

            [JsonProperty("@durability")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Durability { get; set; }

            [JsonProperty("@durabilityloss_attack")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long DurabilitylossAttack { get; set; }

            [JsonProperty("@durabilityloss_spelluse")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long DurabilitylossSpelluse { get; set; }

            [JsonProperty("@durabilityloss_receivedattack")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long DurabilitylossReceivedattack { get; set; }

            [JsonProperty("@durabilityloss_receivedspell")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long DurabilitylossReceivedspell { get; set; }

            [JsonProperty("@mainhandanimationtype")]
            public string Mainhandanimationtype { get; set; }

            [JsonProperty("@unlockedtocraft")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Unlockedtocraft { get; set; }

            [JsonProperty("@unlockedtoequip")]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool Unlockedtoequip { get; set; }

            [JsonProperty("@itempower")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Itempower { get; set; }

            [JsonProperty("@unequipincombat", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Unequipincombat { get; set; }

            [JsonProperty("@uicraftsoundstart")]
            public EquipmentitemUicraftsoundstart Uicraftsoundstart { get; set; }

            [JsonProperty("@uicraftsoundfinish")]
            public EquipmentitemUicraftsoundfinish Uicraftsoundfinish { get; set; }

            [JsonProperty("@canbeovercharged", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Canbeovercharged { get; set; }

            [JsonProperty("canharvest", NullValueHandling = NullValueHandling.Ignore)]
            public Canharvest Canharvest { get; set; }

            [JsonProperty("craftingrequirements")]
            public Craftingrequirements Craftingrequirements { get; set; }

            [JsonProperty("AudioInfo")]
            public AudioInfo AudioInfo { get; set; }

            [JsonProperty("SocketPreset", NullValueHandling = NullValueHandling.Ignore)]
            public AudioInfo SocketPreset { get; set; }

            [JsonProperty("@attackbuildingdamage", NullValueHandling = NullValueHandling.Ignore)]
            public string Attackbuildingdamage { get; set; }

            [JsonProperty("@fishing", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Fishing { get; set; }

            [JsonProperty("@fishingspeed", NullValueHandling = NullValueHandling.Ignore)]
            public string Fishingspeed { get; set; }

            [JsonProperty("@physicalspelldamagebonus", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Physicalspelldamagebonus { get; set; }

            [JsonProperty("@magicspelldamagebonus", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Magicspelldamagebonus { get; set; }

            [JsonProperty("@fxbonename", NullValueHandling = NullValueHandling.Ignore)]
            public Fxbonename? Fxbonename { get; set; }

            [JsonProperty("@fxboneoffset", NullValueHandling = NullValueHandling.Ignore)]
            public Fxboneoffset? Fxboneoffset { get; set; }

            [JsonProperty("@hitpointsmax", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Hitpointsmax { get; set; }

            [JsonProperty("@hitpointsregenerationbonus", NullValueHandling = NullValueHandling.Ignore)]
            public string Hitpointsregenerationbonus { get; set; }

            [JsonProperty("@itempowerprogressiontype", NullValueHandling = NullValueHandling.Ignore)]
            public SlottypeEnum? Itempowerprogressiontype { get; set; }

            [JsonProperty("@focusfireprotectionpeneration", NullValueHandling = NullValueHandling.Ignore)]
            public string Focusfireprotectionpeneration { get; set; }

            [JsonProperty("@craftingcategory", NullValueHandling = NullValueHandling.Ignore)]
            public Craftingcategory? Craftingcategory { get; set; }

            [JsonProperty("@healmodifier", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Healmodifier { get; set; }

            [JsonProperty("projectile", NullValueHandling = NullValueHandling.Ignore)]
            public ProjectileUnion? Projectile { get; set; }

            [JsonProperty("craftingspelllist", NullValueHandling = NullValueHandling.Ignore)]
            public WeaponCraftingspelllist Craftingspelllist { get; set; }

            [JsonProperty("enchantments", NullValueHandling = NullValueHandling.Ignore)]
            public WeaponEnchantments Enchantments { get; set; }

            [JsonProperty("@showinmarketplace", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Showinmarketplace { get; set; }

            [JsonProperty("AssetVfxPreset", NullValueHandling = NullValueHandling.Ignore)]
            public AudioInfo AssetVfxPreset { get; set; }

            [JsonProperty("@attackdamagetimefactor", NullValueHandling = NullValueHandling.Ignore)]
            public string Attackdamagetimefactor { get; set; }
        }

        public class Canharvest
        {
            [JsonProperty("@resourcetype")]
            public CanharvestResourcetype Resourcetype { get; set; }
        }

        public class WeaponCraftingrequirements
        {
            [JsonProperty("@silver")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Silver { get; set; }

            [JsonProperty("@time")]
            public string Time { get; set; }

            [JsonProperty("@craftingfocus")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Craftingfocus { get; set; }

            [JsonProperty("craftresource")]
            public FluffyCraftresource Craftresource { get; set; }

            [JsonProperty("@swaptransaction", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(FluffyParseStringConverter))]
            public bool? Swaptransaction { get; set; }
        }

        public class WeaponCraftingspelllist
        {
            [JsonProperty("craftspell")]
            public StickyCraftspell Craftspell { get; set; }
        }

        public class FluffyCraftspell
        {
            [JsonProperty("@uniquename")]
            public string Uniquename { get; set; }

            [JsonProperty("@slots", NullValueHandling = NullValueHandling.Ignore)]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long? Slots { get; set; }

            [JsonProperty("@tag", NullValueHandling = NullValueHandling.Ignore)]
            public Tag? Tag { get; set; }
        }

        public class WeaponEnchantments
        {
            [JsonProperty("enchantment")]
            public FluffyEnchantment[] Enchantment { get; set; }
        }

        public class FluffyEnchantment
        {
            [JsonProperty("@enchantmentlevel")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Enchantmentlevel { get; set; }

            [JsonProperty("@itempower")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Itempower { get; set; }

            [JsonProperty("@durability")]
            [JsonConverter(typeof(PurpleParseStringConverter))]
            public long Durability { get; set; }

            [JsonProperty("craftingrequirements")]
            public Craftingrequirements Craftingrequirements { get; set; }

            [JsonProperty("upgraderequirements")]
            public Upgraderequirements Upgraderequirements { get; set; }
        }

        public class ProjectileElement
        {
            [JsonProperty("@prefab")]
            public Prefab Prefab { get; set; }

            [JsonProperty("@startsocket")]
            public Startsocket Startsocket { get; set; }

            [JsonProperty("@hitsocket")]
            public Tsocket Hitsocket { get; set; }

            [JsonProperty("impactvfx")]
            public Impactvfx Impactvfx { get; set; }

            [JsonProperty("AudioInfo", NullValueHandling = NullValueHandling.Ignore)]
            public AudioInfo AudioInfo { get; set; }

            [JsonProperty("@timeoffset", NullValueHandling = NullValueHandling.Ignore)]
            public string Timeoffset { get; set; }
        }

        public class Impactvfx
        {
            [JsonProperty("@prefab")]
            public string Prefab { get; set; }

            [JsonProperty("@impactsocket")]
            public Tsocket Impactsocket { get; set; }
        }

        public class Xml
        {
            [JsonProperty("@version")]
            public string Version { get; set; }

            [JsonProperty("@encoding")]
            public string Encoding { get; set; }
        }

        public enum ConsumablefrominventoryitemDescriptionlocatag { ItemsRandomDungeonTokenDesc, ItemsUniqueAvatarringAdcAug2019Desc, ItemsUniqueLootchestAdcAug2019Desc };

        public enum ConsumablefrominventoryitemShopcategory { Consumables };

        public enum ConsumablefrominventoryitemShopsubcategory1 { Other, Potion, Skillbook, Vanity };

        public enum ConsumablefrominventoryitemUicraftsoundfinish { PlayUiActionCraftFoodFinish, PlayUiActionCraftPotionFinish };

        public enum ConsumablefrominventoryitemUicraftsoundstart { PlayUiActionCraftFoodFirmStart, PlayUiActionCraftFoodFryStart, PlayUiActionCraftPotionStart };

        public enum Uispriteoverlay { ItemoverlayGuildVanity, ItemoverlayNonTradable, ItemoverlayVanity };

        public enum ConsumableitemResourcetype { Fish };

        public enum ConsumableitemShopsubcategory1 { Cooked, Fish, Fishingbait, Potion, Vanity };

        public enum ConsumableitemSlottype { Food, Potion };

        public enum Beardstate { Empty, Flat, Half };

        public enum EquipmentitemDescriptionlocatag { ItemsDecorativeEquipmentDesc, ItemsGeneralEquipmentItemDesc };

        public enum Facestate { Empty, Face, Half, Hood };

        public enum Iontype { Armor, Bag, Book, Cane, Cape, Demonskull, Head, Horn, Lamp, Orb, Shield, Shoes, Skullshield, Spikedshield, Torch, Totem, Towershield };

        public enum SlottypeEnum { Armor, Bag, Cape, Head, Mainhand, Offhand, Shoes };

        public enum EquipmentitemUicraftsoundfinish { PlayUiActionCraftClothFinish, PlayUiActionCraftLeatherFinish, PlayUiActionCraftMagicFinish, PlayUiActionCraftMetalFinish, PlayUiActionCraftPlateFinish, PlayUiActionCraftToolFinish, PlayUiActionCraftWoodFinish };

        public enum EquipmentitemUicraftsoundstart { PlayUiActionCraftClothStart, PlayUiActionCraftLeatherStart, PlayUiActionCraftMagicStart, PlayUiActionCraftMetalStart, PlayUiActionCraftPlateStart, PlayUiActionCraftToolStart, PlayUiActionCraftWoodStart };

        public enum Animationid { Breed, Planting, Sow };

        public enum Foodcategory { Meat, Plants };

        public enum Uniquename { FactionForest, FactionHighland, FactionMountain, FactionSteppe, FactionSwamp };

        public enum Faction { Forest, Highland, Mountain, Steppe, Swamp };

        public enum Kind { Animal, Plant };

        public enum FarmableitemShopcategory { Farmables, Products };

        public enum FarmableitemShopsubcategory1 { Animals, Seed };

        public enum FurnitureitemDescriptionlocatag { ItemsFurnitureitemPlayerislandDesc, ItemsFurnitureitemTrophyFiberDesc, ItemsFurnitureitemTrophyFishDesc, ItemsFurnitureitemTrophyGeneralDesc, ItemsFurnitureitemTrophyHideDesc, ItemsFurnitureitemTrophyMercenaryDesc, ItemsFurnitureitemTrophyOreDesc, ItemsFurnitureitemTrophyRockDesc, ItemsFurnitureitemTrophyWoodDesc, ItemsUniqueFurnitureitemAdcGlassSphereADesc };

        public enum Labourerfurnituretype { Bed, Table, Trophy };

        public enum Labourersaffected { All, Fiber, Fishing, Hide, Mercenary, Ore, Rock, Stone, Wood };

        public enum FurnitureitemShopcategory { Furniture, Trophies };

        public enum FurnitureitemUicraftsoundfinish { PlayUiActionCraftFlourFinish, PlayUiActionCraftFoodFinish, PlayUiActionCraftMeatFinish, PlayUiActionCraftRefineFiberFinish, PlayUiActionCraftRefineHideFinish, PlayUiActionCraftRefineOreFinish, PlayUiActionCraftRefineStoneFinish, PlayUiActionCraftRefineWoodFinish };

        public enum FurnitureitemUicraftsoundstart { PlayUiActionCraftFlourStart, PlayUiActionCraftFoodFirmStart, PlayUiActionCraftFoodFryStart, PlayUiActionCraftFoodLiquidStart, PlayUiActionCraftMeatStart, PlayUiActionCraftRefineFiberStart, PlayUiActionCraftRefineHideStart, PlayUiActionCraftRefineOreStart, PlayUiActionCraftRefineStoneStart, PlayUiActionCraftRefineWoodStart };

        public enum JournalitemShopsubcategory1 { Journal };

        public enum Despawneffect { FxClientPrefabsDemountFxBig, FxClientPrefabsDemountFxMedium, FxClientPrefabsDemountFxSmall, FxClientPrefabsDemountFxVerySmall };

        public enum Dismountbuff { Dismounted };

        public enum Spellslot { Armor, Mainhand1, Mainhand2, Offhandormainhand3, Shoes };

        public enum MountShopcategory { Mounts };

        public enum MountShopsubcategory1 { Armoredhorse, Ox, RareMount, Ridinghorse };

        public enum MountSlottype { Mount };

        public enum MountUicraftsoundfinish { PlayMountMounted, PlayUiActionCraftSiegemountFinish };

        public enum MountUicraftsoundstart { PlayUiActionCraftMountStart };

        public enum Buildingfilter { ForestGreenFactionTrader, HighlandGreenFactionTrader, MountainGreenFactionTrader, SteppeGreenFactionTrader, SwampGreenFactionTrader };

        public enum SimpleitemDescriptionlocatag { CaravanTradepackForestHeavyDesc, CaravanTradepackForestLightDesc, CaravanTradepackForestMediumDesc, CaravanTradepackHighlandHeavyDesc, CaravanTradepackHighlandLightDesc, CaravanTradepackHighlandMediumDesc, CaravanTradepackMountainHeavyDesc, CaravanTradepackMountainLightDesc, CaravanTradepackMountainMediumDesc, CaravanTradepackSteppeHeavyDesc, CaravanTradepackSteppeLightDesc, CaravanTradepackSteppeMediumDesc, CaravanTradepackSwampHeavyDesc, CaravanTradepackSwampLightDesc, CaravanTradepackSwampMediumDesc, ExpeditionTokenDesc, ItemsArtefactWeaponDesc, ItemsFishsauceDesc };

        //public enum ShopCategory { Artefacts, Cityresources, Luxurygoods, Materials, Other, Products, Resources, Token, Farmables };

        public enum Attacktype { Magic, Melee, Ranged, Tools };

        public enum CanharvestResourcetype { Fiber, Hide, Ore, Rock, Wood };

        public enum Shopsubcategory1Enum { Arcanestaff, Axe, Bow, Crossbow, Cursestaff, Dagger, Demolitionhammer, Firestaff, Fishing, Froststaff, Hammer, Holystaff, Mace, Naturestaff, Pickaxe, Quarterstaff, Sickle, Skinningknife, Spear, Stonehammer, Sword, Woodaxe };

        public enum Tag { A, B, C, D, E, F, G, H, I };

        public enum Fxbonename { LeftArm3, RightArm3 };

        public enum Fxboneoffset { The0202270135, The133011043 };

        public enum Tsocket { Damage };

        public enum Prefab { FxClientPrefabsFxSpellMagicProjectileArcane, FxClientPrefabsFxSpellMagicProjectileCursed, FxClientPrefabsFxSpellMagicProjectileFire, FxClientPrefabsFxSpellMagicProjectileHoly, FxClientPrefabsFxSpellMagicProjectileIce, FxClientPrefabsFxSpellMagicProjectileNature, FxClientPrefabsFxSpellVanityPortalAutoattackProjectile01, PrefabsVfxProjectilesArrow };

        public enum Startsocket { Mainhandprojectile, Offhandprojectile };

        public struct CraftingrequirementCraftresourceUnion
        {
            public CraftresourceElement CraftresourceElement;
            public CraftresourceElement[] CraftresourceElementArray;

            public static implicit operator CraftingrequirementCraftresourceUnion(CraftresourceElement CraftresourceElement) => new CraftingrequirementCraftresourceUnion { CraftresourceElement = CraftresourceElement };
            public static implicit operator CraftingrequirementCraftresourceUnion(CraftresourceElement[] CraftresourceElementArray) => new CraftingrequirementCraftresourceUnion { CraftresourceElementArray = CraftresourceElementArray };
        }

        public struct PurpleCraftresource
        {
            public Replacementitem Replacementitem;
            public Replacementitem[] ReplacementitemArray;

            public static implicit operator PurpleCraftresource(Replacementitem Replacementitem) => new PurpleCraftresource { Replacementitem = Replacementitem };
            public static implicit operator PurpleCraftresource(Replacementitem[] ReplacementitemArray) => new PurpleCraftresource { ReplacementitemArray = ReplacementitemArray };
        }

        public struct EnchantmentUnion
        {
            public EnchantmentEnchantment EnchantmentEnchantment;
            public EnchantmentEnchantment[] EnchantmentEnchantmentArray;

            public static implicit operator EnchantmentUnion(EnchantmentEnchantment EnchantmentEnchantment) => new EnchantmentUnion { EnchantmentEnchantment = EnchantmentEnchantment };
            public static implicit operator EnchantmentUnion(EnchantmentEnchantment[] EnchantmentEnchantmentArray) => new EnchantmentUnion { EnchantmentEnchantmentArray = EnchantmentEnchantmentArray };
        }

        public struct TentacledCraftspell
        {
            public CraftingspelllistCraftspellClass CraftingspelllistCraftspellClass;
            public PurpleCraftspell[] PurpleCraftspellArray;

            public static implicit operator TentacledCraftspell(CraftingspelllistCraftspellClass CraftingspelllistCraftspellClass) => new TentacledCraftspell { CraftingspelllistCraftspellClass = CraftingspelllistCraftspellClass };
            public static implicit operator TentacledCraftspell(PurpleCraftspell[] PurpleCraftspellArray) => new TentacledCraftspell { PurpleCraftspellArray = PurpleCraftspellArray };
        }

        public struct ValiditemUnion
        {
            public ValiditemElement ValiditemElement;
            public ValiditemElement[] ValiditemElementArray;

            public static implicit operator ValiditemUnion(ValiditemElement ValiditemElement) => new ValiditemUnion { ValiditemElement = ValiditemElement };
            public static implicit operator ValiditemUnion(ValiditemElement[] ValiditemElementArray) => new ValiditemUnion { ValiditemElementArray = ValiditemElementArray };
        }

        public struct LootUnion
        {
            public LootElement LootElement;
            public LootElement[] LootElementArray;

            public static implicit operator LootUnion(LootElement LootElement) => new LootUnion { LootElement = LootElement };
            public static implicit operator LootUnion(LootElement[] LootElementArray) => new LootUnion { LootElementArray = LootElementArray };
        }

        public struct FluffyCraftresource
        {
            public CraftresourceElement[] CraftresourceElementArray;
            public Replacementitem Replacementitem;

            public static implicit operator FluffyCraftresource(CraftresourceElement[] CraftresourceElementArray) => new FluffyCraftresource { CraftresourceElementArray = CraftresourceElementArray };
            public static implicit operator FluffyCraftresource(Replacementitem Replacementitem) => new FluffyCraftresource { Replacementitem = Replacementitem };
        }

        public struct MountspellUnion
        {
            public MountspellElement MountspellElement;
            public MountspellElement[] MountspellElementArray;

            public static implicit operator MountspellUnion(MountspellElement MountspellElement) => new MountspellUnion { MountspellElement = MountspellElement };
            public static implicit operator MountspellUnion(MountspellElement[] MountspellElementArray) => new MountspellUnion { MountspellElementArray = MountspellElementArray };
        }

        public struct TentacledCraftresource
        {
            public CraftresourceElement CraftresourceElement;
            public CraftresourceElement[] ReplacementitemArray;

            public static implicit operator TentacledCraftresource(CraftresourceElement CraftresourceElement) => new TentacledCraftresource { CraftresourceElement = CraftresourceElement };
            public static implicit operator TentacledCraftresource(CraftresourceElement[] ReplacementitemArray) => new TentacledCraftresource { ReplacementitemArray = ReplacementitemArray };
        }

        public struct Craftingrequirements
        {
            public Craftingrequirement[] CraftingrequirementArrayArray;
            public Craftingrequirement Craftingrequirement;

            public static implicit operator Craftingrequirements(Craftingrequirement[] craftingrequirementArrayArray) => new Craftingrequirements { CraftingrequirementArrayArray = craftingrequirementArrayArray };
            public static implicit operator Craftingrequirements(Craftingrequirement craftingrequirement) => new Craftingrequirements { Craftingrequirement = craftingrequirement };
        }

        public struct StickyCraftspell
        {
            public FluffyCraftspell[] FluffyCraftspellArray;
            public PurpleCraftspell PurpleCraftspell;

            public static implicit operator StickyCraftspell(FluffyCraftspell[] FluffyCraftspellArray) => new StickyCraftspell { FluffyCraftspellArray = FluffyCraftspellArray };
            public static implicit operator StickyCraftspell(PurpleCraftspell PurpleCraftspell) => new StickyCraftspell { PurpleCraftspell = PurpleCraftspell };
        }

        public struct ProjectileUnion
        {
            public ProjectileElement ProjectileElement;
            public ProjectileElement[] ProjectileElementArray;

            public static implicit operator ProjectileUnion(ProjectileElement ProjectileElement) => new ProjectileUnion { ProjectileElement = ProjectileElement };
            public static implicit operator ProjectileUnion(ProjectileElement[] ProjectileElementArray) => new ProjectileUnion { ProjectileElementArray = ProjectileElementArray };
        }

        public partial class JsonDb
        {
            public static JsonDb FromJson(string json) => JsonConvert.DeserializeObject<JsonDb>(json, Converter.Settings);
        }

        public static class Serialize
        {
            public static string ToJson(this JsonDb self) => JsonConvert.SerializeObject(self, Converter.Settings);
        }

        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters =
            {
                ConsumablefrominventoryitemDescriptionlocatagConverter.Singleton,
                ConsumablefrominventoryitemShopcategoryConverter.Singleton,
                ConsumablefrominventoryitemShopsubcategory1Converter.Singleton,
                ConsumablefrominventoryitemUicraftsoundfinishConverter.Singleton,
                ConsumablefrominventoryitemUicraftsoundstartConverter.Singleton,
                UispriteoverlayConverter.Singleton,
                CraftingrequirementCraftresourceUnionConverter.Singleton,
                ConsumableitemResourcetypeConverter.Singleton,
                ConsumableitemShopsubcategory1Converter.Singleton,
                ConsumableitemSlottypeConverter.Singleton,
                PurpleCraftresourceConverter.Singleton,
                EnchantmentUnionConverter.Singleton,
                BeardstateConverter.Singleton,
                EquipmentitemDescriptionlocatagConverter.Singleton,
                FacestateConverter.Singleton,
                IontypeConverter.Singleton,
                SlottypeEnumConverter.Singleton,
                EquipmentitemUicraftsoundfinishConverter.Singleton,
                EquipmentitemUicraftsoundstartConverter.Singleton,
                TentacledCraftspellConverter.Singleton,
                AnimationidConverter.Singleton,
                KindConverter.Singleton,
                FarmableitemShopcategoryConverter.Singleton,
                FarmableitemShopsubcategory1Converter.Singleton,
                FoodcategoryConverter.Singleton,
                UniquenameConverter.Singleton,
                FactionConverter.Singleton,
                FurnitureitemDescriptionlocatagConverter.Singleton,
                LabourerfurnituretypeConverter.Singleton,
                LabourersaffectedConverter.Singleton,
                FurnitureitemShopcategoryConverter.Singleton,
                FurnitureitemUicraftsoundfinishConverter.Singleton,
                FurnitureitemUicraftsoundstartConverter.Singleton,
                JournalitemShopsubcategory1Converter.Singleton,
                ValiditemUnionConverter.Singleton,
                LootUnionConverter.Singleton,
                DespawneffectConverter.Singleton,
                DismountbuffConverter.Singleton,
                MountShopcategoryConverter.Singleton,
                MountShopsubcategory1Converter.Singleton,
                MountSlottypeConverter.Singleton,
                MountUicraftsoundfinishConverter.Singleton,
                MountUicraftsoundstartConverter.Singleton,
                FluffyCraftresourceConverter.Singleton,
                MountspellUnionConverter.Singleton,
                SpellslotConverter.Singleton,
                SimpleitemDescriptionlocatagConverter.Singleton,
                //SimpleitemShopcategoryConverter.Singleton,
                SimpleitemCraftingrequirementsConverter.Singleton,
                BuildingfilterConverter.Singleton,
                TentacledCraftresourceConverter.Singleton,
                AttacktypeConverter.Singleton,
                Shopsubcategory1EnumConverter.Singleton,
                FxbonenameConverter.Singleton,
                FxboneoffsetConverter.Singleton,
                CanharvestResourcetypeConverter.Singleton,
                StickyCraftspellConverter.Singleton,
                TagConverter.Singleton,
                ProjectileUnionConverter.Singleton,
                TsocketConverter.Singleton,
                PrefabConverter.Singleton,
                StartsocketConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
            };
        }

        internal class PurpleParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(long) || t == typeof(long?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                long l;
                if (Int64.TryParse(value, out l))
                {
                    return l;
                }
                throw new Exception("Cannot unmarshal type long");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (long)untypedValue;
                serializer.Serialize(writer, value.ToString());
                return;
            }

            public static readonly PurpleParseStringConverter Singleton = new PurpleParseStringConverter();
        }

        internal class ConsumablefrominventoryitemDescriptionlocatagConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ConsumablefrominventoryitemDescriptionlocatag) || t == typeof(ConsumablefrominventoryitemDescriptionlocatag?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "@ITEMS_RANDOM_DUNGEON_TOKEN_DESC":
                        return ConsumablefrominventoryitemDescriptionlocatag.ItemsRandomDungeonTokenDesc;
                    case "@ITEMS_UNIQUE_AVATARRING_ADC_AUG2019_DESC":
                        return ConsumablefrominventoryitemDescriptionlocatag.ItemsUniqueAvatarringAdcAug2019Desc;
                    case "@ITEMS_UNIQUE_LOOTCHEST_ADC_AUG2019_DESC":
                        return ConsumablefrominventoryitemDescriptionlocatag.ItemsUniqueLootchestAdcAug2019Desc;
                }
                throw new Exception("Cannot unmarshal type ConsumablefrominventoryitemDescriptionlocatag");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ConsumablefrominventoryitemDescriptionlocatag)untypedValue;
                switch (value)
                {
                    case ConsumablefrominventoryitemDescriptionlocatag.ItemsRandomDungeonTokenDesc:
                        serializer.Serialize(writer, "@ITEMS_RANDOM_DUNGEON_TOKEN_DESC");
                        return;
                    case ConsumablefrominventoryitemDescriptionlocatag.ItemsUniqueAvatarringAdcAug2019Desc:
                        serializer.Serialize(writer, "@ITEMS_UNIQUE_AVATARRING_ADC_AUG2019_DESC");
                        return;
                    case ConsumablefrominventoryitemDescriptionlocatag.ItemsUniqueLootchestAdcAug2019Desc:
                        serializer.Serialize(writer, "@ITEMS_UNIQUE_LOOTCHEST_ADC_AUG2019_DESC");
                        return;
                }
                throw new Exception("Cannot marshal type ConsumablefrominventoryitemDescriptionlocatag");
            }

            public static readonly ConsumablefrominventoryitemDescriptionlocatagConverter Singleton = new ConsumablefrominventoryitemDescriptionlocatagConverter();
        }

        internal class FluffyParseStringConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(bool) || t == typeof(bool?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                bool b;
                if (Boolean.TryParse(value, out b))
                {
                    return b;
                }
                throw new Exception("Cannot unmarshal type bool");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (bool)untypedValue;
                var boolString = value ? "true" : "false";
                serializer.Serialize(writer, boolString);
                return;
            }

            public static readonly FluffyParseStringConverter Singleton = new FluffyParseStringConverter();
        }

        internal class ConsumablefrominventoryitemShopcategoryConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ConsumablefrominventoryitemShopcategory) || t == typeof(ConsumablefrominventoryitemShopcategory?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "consumables")
                {
                    return ConsumablefrominventoryitemShopcategory.Consumables;
                }
                throw new Exception("Cannot unmarshal type ConsumablefrominventoryitemShopcategory");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ConsumablefrominventoryitemShopcategory)untypedValue;
                if (value == ConsumablefrominventoryitemShopcategory.Consumables)
                {
                    serializer.Serialize(writer, "consumables");
                    return;
                }
                throw new Exception("Cannot marshal type ConsumablefrominventoryitemShopcategory");
            }

            public static readonly ConsumablefrominventoryitemShopcategoryConverter Singleton = new ConsumablefrominventoryitemShopcategoryConverter();
        }

        internal class ConsumablefrominventoryitemShopsubcategory1Converter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ConsumablefrominventoryitemShopsubcategory1) || t == typeof(ConsumablefrominventoryitemShopsubcategory1?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "other":
                        return ConsumablefrominventoryitemShopsubcategory1.Other;
                    case "potion":
                        return ConsumablefrominventoryitemShopsubcategory1.Potion;
                    case "skillbook":
                        return ConsumablefrominventoryitemShopsubcategory1.Skillbook;
                    case "vanity":
                        return ConsumablefrominventoryitemShopsubcategory1.Vanity;
                }
                throw new Exception("Cannot unmarshal type ConsumablefrominventoryitemShopsubcategory1");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ConsumablefrominventoryitemShopsubcategory1)untypedValue;
                switch (value)
                {
                    case ConsumablefrominventoryitemShopsubcategory1.Other:
                        serializer.Serialize(writer, "other");
                        return;
                    case ConsumablefrominventoryitemShopsubcategory1.Potion:
                        serializer.Serialize(writer, "potion");
                        return;
                    case ConsumablefrominventoryitemShopsubcategory1.Skillbook:
                        serializer.Serialize(writer, "skillbook");
                        return;
                    case ConsumablefrominventoryitemShopsubcategory1.Vanity:
                        serializer.Serialize(writer, "vanity");
                        return;
                }
                throw new Exception("Cannot marshal type ConsumablefrominventoryitemShopsubcategory1");
            }

            public static readonly ConsumablefrominventoryitemShopsubcategory1Converter Singleton = new ConsumablefrominventoryitemShopsubcategory1Converter();
        }

        internal class ConsumablefrominventoryitemUicraftsoundfinishConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ConsumablefrominventoryitemUicraftsoundfinish) || t == typeof(ConsumablefrominventoryitemUicraftsoundfinish?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Play_ui_action_craft_food_finish":
                        return ConsumablefrominventoryitemUicraftsoundfinish.PlayUiActionCraftFoodFinish;
                    case "Play_ui_action_craft_potion_finish":
                        return ConsumablefrominventoryitemUicraftsoundfinish.PlayUiActionCraftPotionFinish;
                }
                throw new Exception("Cannot unmarshal type ConsumablefrominventoryitemUicraftsoundfinish");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ConsumablefrominventoryitemUicraftsoundfinish)untypedValue;
                switch (value)
                {
                    case ConsumablefrominventoryitemUicraftsoundfinish.PlayUiActionCraftFoodFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_food_finish");
                        return;
                    case ConsumablefrominventoryitemUicraftsoundfinish.PlayUiActionCraftPotionFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_potion_finish");
                        return;
                }
                throw new Exception("Cannot marshal type ConsumablefrominventoryitemUicraftsoundfinish");
            }

            public static readonly ConsumablefrominventoryitemUicraftsoundfinishConverter Singleton = new ConsumablefrominventoryitemUicraftsoundfinishConverter();
        }

        internal class ConsumablefrominventoryitemUicraftsoundstartConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ConsumablefrominventoryitemUicraftsoundstart) || t == typeof(ConsumablefrominventoryitemUicraftsoundstart?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Play_ui_action_craft_food_firm_start":
                        return ConsumablefrominventoryitemUicraftsoundstart.PlayUiActionCraftFoodFirmStart;
                    case "Play_ui_action_craft_food_fry_start":
                        return ConsumablefrominventoryitemUicraftsoundstart.PlayUiActionCraftFoodFryStart;
                    case "Play_ui_action_craft_potion_start":
                        return ConsumablefrominventoryitemUicraftsoundstart.PlayUiActionCraftPotionStart;
                }
                throw new Exception("Cannot unmarshal type ConsumablefrominventoryitemUicraftsoundstart");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ConsumablefrominventoryitemUicraftsoundstart)untypedValue;
                switch (value)
                {
                    case ConsumablefrominventoryitemUicraftsoundstart.PlayUiActionCraftFoodFirmStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_food_firm_start");
                        return;
                    case ConsumablefrominventoryitemUicraftsoundstart.PlayUiActionCraftFoodFryStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_food_fry_start");
                        return;
                    case ConsumablefrominventoryitemUicraftsoundstart.PlayUiActionCraftPotionStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_potion_start");
                        return;
                }
                throw new Exception("Cannot marshal type ConsumablefrominventoryitemUicraftsoundstart");
            }

            public static readonly ConsumablefrominventoryitemUicraftsoundstartConverter Singleton = new ConsumablefrominventoryitemUicraftsoundstartConverter();
        }

        internal class UispriteoverlayConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Uispriteoverlay) || t == typeof(Uispriteoverlay?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "ITEMOVERLAY_GUILD_VANITY":
                        return Uispriteoverlay.ItemoverlayGuildVanity;
                    case "ITEMOVERLAY_NON_TRADABLE":
                        return Uispriteoverlay.ItemoverlayNonTradable;
                    case "ITEMOVERLAY_VANITY":
                        return Uispriteoverlay.ItemoverlayVanity;
                }
                throw new Exception("Cannot unmarshal type Uispriteoverlay");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Uispriteoverlay)untypedValue;
                switch (value)
                {
                    case Uispriteoverlay.ItemoverlayGuildVanity:
                        serializer.Serialize(writer, "ITEMOVERLAY_GUILD_VANITY");
                        return;
                    case Uispriteoverlay.ItemoverlayNonTradable:
                        serializer.Serialize(writer, "ITEMOVERLAY_NON_TRADABLE");
                        return;
                    case Uispriteoverlay.ItemoverlayVanity:
                        serializer.Serialize(writer, "ITEMOVERLAY_VANITY");
                        return;
                }
                throw new Exception("Cannot marshal type Uispriteoverlay");
            }

            public static readonly UispriteoverlayConverter Singleton = new UispriteoverlayConverter();
        }

        internal class CraftingrequirementCraftresourceUnionConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(CraftingrequirementCraftresourceUnion) || t == typeof(CraftingrequirementCraftresourceUnion?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<CraftresourceElement>(reader);
                        return new CraftingrequirementCraftresourceUnion { CraftresourceElement = objectValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<CraftresourceElement[]>(reader);
                        return new CraftingrequirementCraftresourceUnion { CraftresourceElementArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type CraftingrequirementCraftresourceUnion");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (CraftingrequirementCraftresourceUnion)untypedValue;
                if (value.CraftresourceElementArray != null)
                {
                    serializer.Serialize(writer, value.CraftresourceElementArray);
                    return;
                }
                if (value.CraftresourceElement != null)
                {
                    serializer.Serialize(writer, value.CraftresourceElement);
                    return;
                }
                throw new Exception("Cannot marshal type CraftingrequirementCraftresourceUnion");
            }

            public static readonly CraftingrequirementCraftresourceUnionConverter Singleton = new CraftingrequirementCraftresourceUnionConverter();
        }

        internal class ConsumableitemResourcetypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ConsumableitemResourcetype) || t == typeof(ConsumableitemResourcetype?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "FISH")
                {
                    return ConsumableitemResourcetype.Fish;
                }
                throw new Exception("Cannot unmarshal type ConsumableitemResourcetype");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ConsumableitemResourcetype)untypedValue;
                if (value == ConsumableitemResourcetype.Fish)
                {
                    serializer.Serialize(writer, "FISH");
                    return;
                }
                throw new Exception("Cannot marshal type ConsumableitemResourcetype");
            }

            public static readonly ConsumableitemResourcetypeConverter Singleton = new ConsumableitemResourcetypeConverter();
        }

        internal class ConsumableitemShopsubcategory1Converter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ConsumableitemShopsubcategory1) || t == typeof(ConsumableitemShopsubcategory1?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "cooked":
                        return ConsumableitemShopsubcategory1.Cooked;
                    case "fish":
                        return ConsumableitemShopsubcategory1.Fish;
                    case "fishingbait":
                        return ConsumableitemShopsubcategory1.Fishingbait;
                    case "potion":
                        return ConsumableitemShopsubcategory1.Potion;
                    case "vanity":
                        return ConsumableitemShopsubcategory1.Vanity;
                }
                throw new Exception("Cannot unmarshal type ConsumableitemShopsubcategory1");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ConsumableitemShopsubcategory1)untypedValue;
                switch (value)
                {
                    case ConsumableitemShopsubcategory1.Cooked:
                        serializer.Serialize(writer, "cooked");
                        return;
                    case ConsumableitemShopsubcategory1.Fish:
                        serializer.Serialize(writer, "fish");
                        return;
                    case ConsumableitemShopsubcategory1.Fishingbait:
                        serializer.Serialize(writer, "fishingbait");
                        return;
                    case ConsumableitemShopsubcategory1.Potion:
                        serializer.Serialize(writer, "potion");
                        return;
                    case ConsumableitemShopsubcategory1.Vanity:
                        serializer.Serialize(writer, "vanity");
                        return;
                }
                throw new Exception("Cannot marshal type ConsumableitemShopsubcategory1");
            }

            public static readonly ConsumableitemShopsubcategory1Converter Singleton = new ConsumableitemShopsubcategory1Converter();
        }

        internal class ConsumableitemSlottypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ConsumableitemSlottype) || t == typeof(ConsumableitemSlottype?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "food":
                        return ConsumableitemSlottype.Food;
                    case "potion":
                        return ConsumableitemSlottype.Potion;
                }
                throw new Exception("Cannot unmarshal type ConsumableitemSlottype");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (ConsumableitemSlottype)untypedValue;
                switch (value)
                {
                    case ConsumableitemSlottype.Food:
                        serializer.Serialize(writer, "food");
                        return;
                    case ConsumableitemSlottype.Potion:
                        serializer.Serialize(writer, "potion");
                        return;
                }
                throw new Exception("Cannot marshal type ConsumableitemSlottype");
            }

            public static readonly ConsumableitemSlottypeConverter Singleton = new ConsumableitemSlottypeConverter();
        }

        internal class PurpleCraftresourceConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(PurpleCraftresource) || t == typeof(PurpleCraftresource?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<Replacementitem>(reader);
                        return new PurpleCraftresource { Replacementitem = objectValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<Replacementitem[]>(reader);
                        return new PurpleCraftresource { ReplacementitemArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type PurpleCraftresource");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (PurpleCraftresource)untypedValue;
                if (value.ReplacementitemArray != null)
                {
                    serializer.Serialize(writer, value.ReplacementitemArray);
                    return;
                }
                if (value.Replacementitem != null)
                {
                    serializer.Serialize(writer, value.Replacementitem);
                    return;
                }
                throw new Exception("Cannot marshal type PurpleCraftresource");
            }

            public static readonly PurpleCraftresourceConverter Singleton = new PurpleCraftresourceConverter();
        }

        internal class EnchantmentUnionConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(EnchantmentUnion) || t == typeof(EnchantmentUnion?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<EnchantmentEnchantment>(reader);
                        return new EnchantmentUnion { EnchantmentEnchantment = objectValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<EnchantmentEnchantment[]>(reader);
                        return new EnchantmentUnion { EnchantmentEnchantmentArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type EnchantmentUnion");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (EnchantmentUnion)untypedValue;
                if (value.EnchantmentEnchantmentArray != null)
                {
                    serializer.Serialize(writer, value.EnchantmentEnchantmentArray);
                    return;
                }
                if (value.EnchantmentEnchantment != null)
                {
                    serializer.Serialize(writer, value.EnchantmentEnchantment);
                    return;
                }
                throw new Exception("Cannot marshal type EnchantmentUnion");
            }

            public static readonly EnchantmentUnionConverter Singleton = new EnchantmentUnionConverter();
        }

        internal class BeardstateConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Beardstate) || t == typeof(Beardstate?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "EMPTY":
                        return Beardstate.Empty;
                    case "FLAT":
                        return Beardstate.Flat;
                    case "HALF":
                        return Beardstate.Half;
                }
                throw new Exception("Cannot unmarshal type Beardstate");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Beardstate)untypedValue;
                switch (value)
                {
                    case Beardstate.Empty:
                        serializer.Serialize(writer, "EMPTY");
                        return;
                    case Beardstate.Flat:
                        serializer.Serialize(writer, "FLAT");
                        return;
                    case Beardstate.Half:
                        serializer.Serialize(writer, "HALF");
                        return;
                }
                throw new Exception("Cannot marshal type Beardstate");
            }

            public static readonly BeardstateConverter Singleton = new BeardstateConverter();
        }

        internal class EquipmentitemDescriptionlocatagConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(EquipmentitemDescriptionlocatag) || t == typeof(EquipmentitemDescriptionlocatag?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "@ITEMS_DECORATIVE_EQUIPMENT_DESC":
                        return EquipmentitemDescriptionlocatag.ItemsDecorativeEquipmentDesc;
                    case "@ITEMS_GENERAL_EQUIPMENT_ITEM_DESC":
                        return EquipmentitemDescriptionlocatag.ItemsGeneralEquipmentItemDesc;
                }
                throw new Exception("Cannot unmarshal type EquipmentitemDescriptionlocatag");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (EquipmentitemDescriptionlocatag)untypedValue;
                switch (value)
                {
                    case EquipmentitemDescriptionlocatag.ItemsDecorativeEquipmentDesc:
                        serializer.Serialize(writer, "@ITEMS_DECORATIVE_EQUIPMENT_DESC");
                        return;
                    case EquipmentitemDescriptionlocatag.ItemsGeneralEquipmentItemDesc:
                        serializer.Serialize(writer, "@ITEMS_GENERAL_EQUIPMENT_ITEM_DESC");
                        return;
                }
                throw new Exception("Cannot marshal type EquipmentitemDescriptionlocatag");
            }

            public static readonly EquipmentitemDescriptionlocatagConverter Singleton = new EquipmentitemDescriptionlocatagConverter();
        }

        internal class FacestateConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Facestate) || t == typeof(Facestate?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "EMPTY":
                        return Facestate.Empty;
                    case "FACE":
                        return Facestate.Face;
                    case "HALF":
                        return Facestate.Half;
                    case "HOOD":
                        return Facestate.Hood;
                }
                throw new Exception("Cannot unmarshal type Facestate");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Facestate)untypedValue;
                switch (value)
                {
                    case Facestate.Empty:
                        serializer.Serialize(writer, "EMPTY");
                        return;
                    case Facestate.Face:
                        serializer.Serialize(writer, "FACE");
                        return;
                    case Facestate.Half:
                        serializer.Serialize(writer, "HALF");
                        return;
                    case Facestate.Hood:
                        serializer.Serialize(writer, "HOOD");
                        return;
                }
                throw new Exception("Cannot marshal type Facestate");
            }

            public static readonly FacestateConverter Singleton = new FacestateConverter();
        }

        internal class IontypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Iontype) || t == typeof(Iontype?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "armor":
                        return Iontype.Armor;
                    case "bag":
                        return Iontype.Bag;
                    case "book":
                        return Iontype.Book;
                    case "cane":
                        return Iontype.Cane;
                    case "cape":
                        return Iontype.Cape;
                    case "demonskull":
                        return Iontype.Demonskull;
                    case "head":
                        return Iontype.Head;
                    case "horn":
                        return Iontype.Horn;
                    case "lamp":
                        return Iontype.Lamp;
                    case "orb":
                        return Iontype.Orb;
                    case "shield":
                        return Iontype.Shield;
                    case "shoes":
                        return Iontype.Shoes;
                    case "skullshield":
                        return Iontype.Skullshield;
                    case "spikedshield":
                        return Iontype.Spikedshield;
                    case "torch":
                        return Iontype.Torch;
                    case "totem":
                        return Iontype.Totem;
                    case "towershield":
                        return Iontype.Towershield;
                }
                throw new Exception("Cannot unmarshal type Iontype");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Iontype)untypedValue;
                switch (value)
                {
                    case Iontype.Armor:
                        serializer.Serialize(writer, "armor");
                        return;
                    case Iontype.Bag:
                        serializer.Serialize(writer, "bag");
                        return;
                    case Iontype.Book:
                        serializer.Serialize(writer, "book");
                        return;
                    case Iontype.Cane:
                        serializer.Serialize(writer, "cane");
                        return;
                    case Iontype.Cape:
                        serializer.Serialize(writer, "cape");
                        return;
                    case Iontype.Demonskull:
                        serializer.Serialize(writer, "demonskull");
                        return;
                    case Iontype.Head:
                        serializer.Serialize(writer, "head");
                        return;
                    case Iontype.Horn:
                        serializer.Serialize(writer, "horn");
                        return;
                    case Iontype.Lamp:
                        serializer.Serialize(writer, "lamp");
                        return;
                    case Iontype.Orb:
                        serializer.Serialize(writer, "orb");
                        return;
                    case Iontype.Shield:
                        serializer.Serialize(writer, "shield");
                        return;
                    case Iontype.Shoes:
                        serializer.Serialize(writer, "shoes");
                        return;
                    case Iontype.Skullshield:
                        serializer.Serialize(writer, "skullshield");
                        return;
                    case Iontype.Spikedshield:
                        serializer.Serialize(writer, "spikedshield");
                        return;
                    case Iontype.Torch:
                        serializer.Serialize(writer, "torch");
                        return;
                    case Iontype.Totem:
                        serializer.Serialize(writer, "totem");
                        return;
                    case Iontype.Towershield:
                        serializer.Serialize(writer, "towershield");
                        return;
                }
                throw new Exception("Cannot marshal type Iontype");
            }

            public static readonly IontypeConverter Singleton = new IontypeConverter();
        }

        internal class SlottypeEnumConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(SlottypeEnum) || t == typeof(SlottypeEnum?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "armor":
                        return SlottypeEnum.Armor;
                    case "bag":
                        return SlottypeEnum.Bag;
                    case "cape":
                        return SlottypeEnum.Cape;
                    case "head":
                        return SlottypeEnum.Head;
                    case "mainhand":
                        return SlottypeEnum.Mainhand;
                    case "offhand":
                        return SlottypeEnum.Offhand;
                    case "shoes":
                        return SlottypeEnum.Shoes;
                }
                throw new Exception("Cannot unmarshal type SlottypeEnum");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (SlottypeEnum)untypedValue;
                switch (value)
                {
                    case SlottypeEnum.Armor:
                        serializer.Serialize(writer, "armor");
                        return;
                    case SlottypeEnum.Bag:
                        serializer.Serialize(writer, "bag");
                        return;
                    case SlottypeEnum.Cape:
                        serializer.Serialize(writer, "cape");
                        return;
                    case SlottypeEnum.Head:
                        serializer.Serialize(writer, "head");
                        return;
                    case SlottypeEnum.Mainhand:
                        serializer.Serialize(writer, "mainhand");
                        return;
                    case SlottypeEnum.Offhand:
                        serializer.Serialize(writer, "offhand");
                        return;
                    case SlottypeEnum.Shoes:
                        serializer.Serialize(writer, "shoes");
                        return;
                }
                throw new Exception("Cannot marshal type SlottypeEnum");
            }

            public static readonly SlottypeEnumConverter Singleton = new SlottypeEnumConverter();
        }

        internal class EquipmentitemUicraftsoundfinishConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(EquipmentitemUicraftsoundfinish) || t == typeof(EquipmentitemUicraftsoundfinish?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Play_ui_action_craft_cloth_finish":
                        return EquipmentitemUicraftsoundfinish.PlayUiActionCraftClothFinish;
                    case "Play_ui_action_craft_leather_finish":
                        return EquipmentitemUicraftsoundfinish.PlayUiActionCraftLeatherFinish;
                    case "Play_ui_action_craft_magic_finish":
                        return EquipmentitemUicraftsoundfinish.PlayUiActionCraftMagicFinish;
                    case "Play_ui_action_craft_metal_finish":
                        return EquipmentitemUicraftsoundfinish.PlayUiActionCraftMetalFinish;
                    case "Play_ui_action_craft_plate_finish":
                        return EquipmentitemUicraftsoundfinish.PlayUiActionCraftPlateFinish;
                    case "Play_ui_action_craft_tool_finish":
                        return EquipmentitemUicraftsoundfinish.PlayUiActionCraftToolFinish;
                    case "Play_ui_action_craft_wood_finish":
                        return EquipmentitemUicraftsoundfinish.PlayUiActionCraftWoodFinish;
                }
                throw new Exception("Cannot unmarshal type EquipmentitemUicraftsoundfinish");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (EquipmentitemUicraftsoundfinish)untypedValue;
                switch (value)
                {
                    case EquipmentitemUicraftsoundfinish.PlayUiActionCraftClothFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_cloth_finish");
                        return;
                    case EquipmentitemUicraftsoundfinish.PlayUiActionCraftLeatherFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_leather_finish");
                        return;
                    case EquipmentitemUicraftsoundfinish.PlayUiActionCraftMagicFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_magic_finish");
                        return;
                    case EquipmentitemUicraftsoundfinish.PlayUiActionCraftMetalFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_metal_finish");
                        return;
                    case EquipmentitemUicraftsoundfinish.PlayUiActionCraftPlateFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_plate_finish");
                        return;
                    case EquipmentitemUicraftsoundfinish.PlayUiActionCraftToolFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_tool_finish");
                        return;
                    case EquipmentitemUicraftsoundfinish.PlayUiActionCraftWoodFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_wood_finish");
                        return;
                }
                throw new Exception("Cannot marshal type EquipmentitemUicraftsoundfinish");
            }

            public static readonly EquipmentitemUicraftsoundfinishConverter Singleton = new EquipmentitemUicraftsoundfinishConverter();
        }

        internal class EquipmentitemUicraftsoundstartConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(EquipmentitemUicraftsoundstart) || t == typeof(EquipmentitemUicraftsoundstart?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Play_ui_action_craft_cloth_start":
                        return EquipmentitemUicraftsoundstart.PlayUiActionCraftClothStart;
                    case "Play_ui_action_craft_leather_start":
                        return EquipmentitemUicraftsoundstart.PlayUiActionCraftLeatherStart;
                    case "Play_ui_action_craft_magic_start":
                        return EquipmentitemUicraftsoundstart.PlayUiActionCraftMagicStart;
                    case "Play_ui_action_craft_metal_start":
                        return EquipmentitemUicraftsoundstart.PlayUiActionCraftMetalStart;
                    case "Play_ui_action_craft_plate_start":
                        return EquipmentitemUicraftsoundstart.PlayUiActionCraftPlateStart;
                    case "Play_ui_action_craft_tool_start":
                        return EquipmentitemUicraftsoundstart.PlayUiActionCraftToolStart;
                    case "Play_ui_action_craft_wood_start":
                        return EquipmentitemUicraftsoundstart.PlayUiActionCraftWoodStart;
                }
                throw new Exception("Cannot unmarshal type EquipmentitemUicraftsoundstart");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (EquipmentitemUicraftsoundstart)untypedValue;
                switch (value)
                {
                    case EquipmentitemUicraftsoundstart.PlayUiActionCraftClothStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_cloth_start");
                        return;
                    case EquipmentitemUicraftsoundstart.PlayUiActionCraftLeatherStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_leather_start");
                        return;
                    case EquipmentitemUicraftsoundstart.PlayUiActionCraftMagicStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_magic_start");
                        return;
                    case EquipmentitemUicraftsoundstart.PlayUiActionCraftMetalStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_metal_start");
                        return;
                    case EquipmentitemUicraftsoundstart.PlayUiActionCraftPlateStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_plate_start");
                        return;
                    case EquipmentitemUicraftsoundstart.PlayUiActionCraftToolStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_tool_start");
                        return;
                    case EquipmentitemUicraftsoundstart.PlayUiActionCraftWoodStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_wood_start");
                        return;
                }
                throw new Exception("Cannot marshal type EquipmentitemUicraftsoundstart");
            }

            public static readonly EquipmentitemUicraftsoundstartConverter Singleton = new EquipmentitemUicraftsoundstartConverter();
        }

        internal class TentacledCraftspellConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(TentacledCraftspell) || t == typeof(TentacledCraftspell?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<CraftingspelllistCraftspellClass>(reader);
                        return new TentacledCraftspell { CraftingspelllistCraftspellClass = objectValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<PurpleCraftspell[]>(reader);
                        return new TentacledCraftspell { PurpleCraftspellArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type TentacledCraftspell");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (TentacledCraftspell)untypedValue;
                if (value.PurpleCraftspellArray != null)
                {
                    serializer.Serialize(writer, value.PurpleCraftspellArray);
                    return;
                }
                if (value.CraftingspelllistCraftspellClass != null)
                {
                    serializer.Serialize(writer, value.CraftingspelllistCraftspellClass);
                    return;
                }
                throw new Exception("Cannot marshal type TentacledCraftspell");
            }

            public static readonly TentacledCraftspellConverter Singleton = new TentacledCraftspellConverter();
        }

        internal class AnimationidConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Animationid) || t == typeof(Animationid?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "breed":
                        return Animationid.Breed;
                    case "planting":
                        return Animationid.Planting;
                    case "sow":
                        return Animationid.Sow;
                }
                throw new Exception("Cannot unmarshal type Animationid");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Animationid)untypedValue;
                switch (value)
                {
                    case Animationid.Breed:
                        serializer.Serialize(writer, "breed");
                        return;
                    case Animationid.Planting:
                        serializer.Serialize(writer, "planting");
                        return;
                    case Animationid.Sow:
                        serializer.Serialize(writer, "sow");
                        return;
                }
                throw new Exception("Cannot marshal type Animationid");
            }

            public static readonly AnimationidConverter Singleton = new AnimationidConverter();
        }

        internal class KindConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Kind) || t == typeof(Kind?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "animal":
                        return Kind.Animal;
                    case "plant":
                        return Kind.Plant;
                }
                throw new Exception("Cannot unmarshal type Kind");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Kind)untypedValue;
                switch (value)
                {
                    case Kind.Animal:
                        serializer.Serialize(writer, "animal");
                        return;
                    case Kind.Plant:
                        serializer.Serialize(writer, "plant");
                        return;
                }
                throw new Exception("Cannot marshal type Kind");
            }

            public static readonly KindConverter Singleton = new KindConverter();
        }

        internal class FarmableitemShopcategoryConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(FarmableitemShopcategory) || t == typeof(FarmableitemShopcategory?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "farmables":
                        return FarmableitemShopcategory.Farmables;
                    case "products":
                        return FarmableitemShopcategory.Products;
                }
                throw new Exception("Cannot unmarshal type FarmableitemShopcategory");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (FarmableitemShopcategory)untypedValue;
                switch (value)
                {
                    case FarmableitemShopcategory.Farmables:
                        serializer.Serialize(writer, "farmables");
                        return;
                    case FarmableitemShopcategory.Products:
                        serializer.Serialize(writer, "products");
                        return;
                }
                throw new Exception("Cannot marshal type FarmableitemShopcategory");
            }

            public static readonly FarmableitemShopcategoryConverter Singleton = new FarmableitemShopcategoryConverter();
        }

        internal class FarmableitemShopsubcategory1Converter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(FarmableitemShopsubcategory1) || t == typeof(FarmableitemShopsubcategory1?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "animals":
                        return FarmableitemShopsubcategory1.Animals;
                    case "seed":
                        return FarmableitemShopsubcategory1.Seed;
                }
                throw new Exception("Cannot unmarshal type FarmableitemShopsubcategory1");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (FarmableitemShopsubcategory1)untypedValue;
                switch (value)
                {
                    case FarmableitemShopsubcategory1.Animals:
                        serializer.Serialize(writer, "animals");
                        return;
                    case FarmableitemShopsubcategory1.Seed:
                        serializer.Serialize(writer, "seed");
                        return;
                }
                throw new Exception("Cannot marshal type FarmableitemShopsubcategory1");
            }

            public static readonly FarmableitemShopsubcategory1Converter Singleton = new FarmableitemShopsubcategory1Converter();
        }

        internal class FoodcategoryConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Foodcategory) || t == typeof(Foodcategory?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "meat":
                        return Foodcategory.Meat;
                    case "plants":
                        return Foodcategory.Plants;
                }
                throw new Exception("Cannot unmarshal type Foodcategory");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Foodcategory)untypedValue;
                switch (value)
                {
                    case Foodcategory.Meat:
                        serializer.Serialize(writer, "meat");
                        return;
                    case Foodcategory.Plants:
                        serializer.Serialize(writer, "plants");
                        return;
                }
                throw new Exception("Cannot marshal type Foodcategory");
            }

            public static readonly FoodcategoryConverter Singleton = new FoodcategoryConverter();
        }

        internal class UniquenameConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Uniquename) || t == typeof(Uniquename?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "FACTION_FOREST":
                        return Uniquename.FactionForest;
                    case "FACTION_HIGHLAND":
                        return Uniquename.FactionHighland;
                    case "FACTION_MOUNTAIN":
                        return Uniquename.FactionMountain;
                    case "FACTION_STEPPE":
                        return Uniquename.FactionSteppe;
                    case "FACTION_SWAMP":
                        return Uniquename.FactionSwamp;
                }
                throw new Exception("Cannot unmarshal type Uniquename");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Uniquename)untypedValue;
                switch (value)
                {
                    case Uniquename.FactionForest:
                        serializer.Serialize(writer, "FACTION_FOREST");
                        return;
                    case Uniquename.FactionHighland:
                        serializer.Serialize(writer, "FACTION_HIGHLAND");
                        return;
                    case Uniquename.FactionMountain:
                        serializer.Serialize(writer, "FACTION_MOUNTAIN");
                        return;
                    case Uniquename.FactionSteppe:
                        serializer.Serialize(writer, "FACTION_STEPPE");
                        return;
                    case Uniquename.FactionSwamp:
                        serializer.Serialize(writer, "FACTION_SWAMP");
                        return;
                }
                throw new Exception("Cannot marshal type Uniquename");
            }

            public static readonly UniquenameConverter Singleton = new UniquenameConverter();
        }

        internal class FactionConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Faction) || t == typeof(Faction?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Forest":
                        return Faction.Forest;
                    case "Highland":
                        return Faction.Highland;
                    case "Mountain":
                        return Faction.Mountain;
                    case "Steppe":
                        return Faction.Steppe;
                    case "Swamp":
                        return Faction.Swamp;
                }
                throw new Exception("Cannot unmarshal type Faction");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Faction)untypedValue;
                switch (value)
                {
                    case Faction.Forest:
                        serializer.Serialize(writer, "Forest");
                        return;
                    case Faction.Highland:
                        serializer.Serialize(writer, "Highland");
                        return;
                    case Faction.Mountain:
                        serializer.Serialize(writer, "Mountain");
                        return;
                    case Faction.Steppe:
                        serializer.Serialize(writer, "Steppe");
                        return;
                    case Faction.Swamp:
                        serializer.Serialize(writer, "Swamp");
                        return;
                }
                throw new Exception("Cannot marshal type Faction");
            }

            public static readonly FactionConverter Singleton = new FactionConverter();
        }

        internal class FurnitureitemDescriptionlocatagConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(FurnitureitemDescriptionlocatag) || t == typeof(FurnitureitemDescriptionlocatag?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "@ITEMS_FURNITUREITEM_PLAYERISLAND_DESC":
                        return FurnitureitemDescriptionlocatag.ItemsFurnitureitemPlayerislandDesc;
                    case "@ITEMS_FURNITUREITEM_TROPHY_FIBER_DESC":
                        return FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyFiberDesc;
                    case "@ITEMS_FURNITUREITEM_TROPHY_FISH_DESC":
                        return FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyFishDesc;
                    case "@ITEMS_FURNITUREITEM_TROPHY_GENERAL_DESC":
                        return FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyGeneralDesc;
                    case "@ITEMS_FURNITUREITEM_TROPHY_HIDE_DESC":
                        return FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyHideDesc;
                    case "@ITEMS_FURNITUREITEM_TROPHY_MERCENARY_DESC":
                        return FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyMercenaryDesc;
                    case "@ITEMS_FURNITUREITEM_TROPHY_ORE_DESC":
                        return FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyOreDesc;
                    case "@ITEMS_FURNITUREITEM_TROPHY_ROCK_DESC":
                        return FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyRockDesc;
                    case "@ITEMS_FURNITUREITEM_TROPHY_WOOD_DESC":
                        return FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyWoodDesc;
                    case "@ITEMS_UNIQUE_FURNITUREITEM_ADC_GLASS_SPHERE_A_DESC":
                        return FurnitureitemDescriptionlocatag.ItemsUniqueFurnitureitemAdcGlassSphereADesc;
                }
                throw new Exception("Cannot unmarshal type FurnitureitemDescriptionlocatag");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (FurnitureitemDescriptionlocatag)untypedValue;
                switch (value)
                {
                    case FurnitureitemDescriptionlocatag.ItemsFurnitureitemPlayerislandDesc:
                        serializer.Serialize(writer, "@ITEMS_FURNITUREITEM_PLAYERISLAND_DESC");
                        return;
                    case FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyFiberDesc:
                        serializer.Serialize(writer, "@ITEMS_FURNITUREITEM_TROPHY_FIBER_DESC");
                        return;
                    case FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyFishDesc:
                        serializer.Serialize(writer, "@ITEMS_FURNITUREITEM_TROPHY_FISH_DESC");
                        return;
                    case FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyGeneralDesc:
                        serializer.Serialize(writer, "@ITEMS_FURNITUREITEM_TROPHY_GENERAL_DESC");
                        return;
                    case FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyHideDesc:
                        serializer.Serialize(writer, "@ITEMS_FURNITUREITEM_TROPHY_HIDE_DESC");
                        return;
                    case FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyMercenaryDesc:
                        serializer.Serialize(writer, "@ITEMS_FURNITUREITEM_TROPHY_MERCENARY_DESC");
                        return;
                    case FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyOreDesc:
                        serializer.Serialize(writer, "@ITEMS_FURNITUREITEM_TROPHY_ORE_DESC");
                        return;
                    case FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyRockDesc:
                        serializer.Serialize(writer, "@ITEMS_FURNITUREITEM_TROPHY_ROCK_DESC");
                        return;
                    case FurnitureitemDescriptionlocatag.ItemsFurnitureitemTrophyWoodDesc:
                        serializer.Serialize(writer, "@ITEMS_FURNITUREITEM_TROPHY_WOOD_DESC");
                        return;
                    case FurnitureitemDescriptionlocatag.ItemsUniqueFurnitureitemAdcGlassSphereADesc:
                        serializer.Serialize(writer, "@ITEMS_UNIQUE_FURNITUREITEM_ADC_GLASS_SPHERE_A_DESC");
                        return;
                }
                throw new Exception("Cannot marshal type FurnitureitemDescriptionlocatag");
            }

            public static readonly FurnitureitemDescriptionlocatagConverter Singleton = new FurnitureitemDescriptionlocatagConverter();
        }

        internal class LabourerfurnituretypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Labourerfurnituretype) || t == typeof(Labourerfurnituretype?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "bed":
                        return Labourerfurnituretype.Bed;
                    case "table":
                        return Labourerfurnituretype.Table;
                    case "trophy":
                        return Labourerfurnituretype.Trophy;
                }
                throw new Exception("Cannot unmarshal type Labourerfurnituretype");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Labourerfurnituretype)untypedValue;
                switch (value)
                {
                    case Labourerfurnituretype.Bed:
                        serializer.Serialize(writer, "bed");
                        return;
                    case Labourerfurnituretype.Table:
                        serializer.Serialize(writer, "table");
                        return;
                    case Labourerfurnituretype.Trophy:
                        serializer.Serialize(writer, "trophy");
                        return;
                }
                throw new Exception("Cannot marshal type Labourerfurnituretype");
            }

            public static readonly LabourerfurnituretypeConverter Singleton = new LabourerfurnituretypeConverter();
        }

        internal class LabourersaffectedConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Labourersaffected) || t == typeof(Labourersaffected?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "all":
                        return Labourersaffected.All;
                    case "fiber":
                        return Labourersaffected.Fiber;
                    case "fishing":
                        return Labourersaffected.Fishing;
                    case "hide":
                        return Labourersaffected.Hide;
                    case "mercenary":
                        return Labourersaffected.Mercenary;
                    case "ore":
                        return Labourersaffected.Ore;
                    case "rock":
                        return Labourersaffected.Rock;
                    case "stone":
                        return Labourersaffected.Stone;
                    case "wood":
                        return Labourersaffected.Wood;
                }
                throw new Exception("Cannot unmarshal type Labourersaffected");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Labourersaffected)untypedValue;
                switch (value)
                {
                    case Labourersaffected.All:
                        serializer.Serialize(writer, "all");
                        return;
                    case Labourersaffected.Fiber:
                        serializer.Serialize(writer, "fiber");
                        return;
                    case Labourersaffected.Fishing:
                        serializer.Serialize(writer, "fishing");
                        return;
                    case Labourersaffected.Hide:
                        serializer.Serialize(writer, "hide");
                        return;
                    case Labourersaffected.Mercenary:
                        serializer.Serialize(writer, "mercenary");
                        return;
                    case Labourersaffected.Ore:
                        serializer.Serialize(writer, "ore");
                        return;
                    case Labourersaffected.Rock:
                        serializer.Serialize(writer, "rock");
                        return;
                    case Labourersaffected.Stone:
                        serializer.Serialize(writer, "stone");
                        return;
                    case Labourersaffected.Wood:
                        serializer.Serialize(writer, "wood");
                        return;
                }
                throw new Exception("Cannot marshal type Labourersaffected");
            }

            public static readonly LabourersaffectedConverter Singleton = new LabourersaffectedConverter();
        }

        internal class FurnitureitemShopcategoryConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(FurnitureitemShopcategory) || t == typeof(FurnitureitemShopcategory?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "furniture":
                        return FurnitureitemShopcategory.Furniture;
                    case "trophies":
                        return FurnitureitemShopcategory.Trophies;
                }
                throw new Exception("Cannot unmarshal type FurnitureitemShopcategory");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (FurnitureitemShopcategory)untypedValue;
                switch (value)
                {
                    case FurnitureitemShopcategory.Furniture:
                        serializer.Serialize(writer, "furniture");
                        return;
                    case FurnitureitemShopcategory.Trophies:
                        serializer.Serialize(writer, "trophies");
                        return;
                }
                throw new Exception("Cannot marshal type FurnitureitemShopcategory");
            }

            public static readonly FurnitureitemShopcategoryConverter Singleton = new FurnitureitemShopcategoryConverter();
        }

        internal class FurnitureitemUicraftsoundfinishConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(FurnitureitemUicraftsoundfinish) || t == typeof(FurnitureitemUicraftsoundfinish?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Play_ui_action_craft_flour_finish":
                        return FurnitureitemUicraftsoundfinish.PlayUiActionCraftFlourFinish;
                    case "Play_ui_action_craft_food_finish":
                        return FurnitureitemUicraftsoundfinish.PlayUiActionCraftFoodFinish;
                    case "Play_ui_action_craft_meat_finish":
                        return FurnitureitemUicraftsoundfinish.PlayUiActionCraftMeatFinish;
                    case "Play_ui_action_craft_refine_fiber_finish":
                        return FurnitureitemUicraftsoundfinish.PlayUiActionCraftRefineFiberFinish;
                    case "Play_ui_action_craft_refine_hide_finish":
                        return FurnitureitemUicraftsoundfinish.PlayUiActionCraftRefineHideFinish;
                    case "Play_ui_action_craft_refine_ore_finish":
                        return FurnitureitemUicraftsoundfinish.PlayUiActionCraftRefineOreFinish;
                    case "Play_ui_action_craft_refine_stone_finish":
                        return FurnitureitemUicraftsoundfinish.PlayUiActionCraftRefineStoneFinish;
                    case "Play_ui_action_craft_refine_wood_finish":
                        return FurnitureitemUicraftsoundfinish.PlayUiActionCraftRefineWoodFinish;
                }
                throw new Exception("Cannot unmarshal type FurnitureitemUicraftsoundfinish");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (FurnitureitemUicraftsoundfinish)untypedValue;
                switch (value)
                {
                    case FurnitureitemUicraftsoundfinish.PlayUiActionCraftFlourFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_flour_finish");
                        return;
                    case FurnitureitemUicraftsoundfinish.PlayUiActionCraftFoodFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_food_finish");
                        return;
                    case FurnitureitemUicraftsoundfinish.PlayUiActionCraftMeatFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_meat_finish");
                        return;
                    case FurnitureitemUicraftsoundfinish.PlayUiActionCraftRefineFiberFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_refine_fiber_finish");
                        return;
                    case FurnitureitemUicraftsoundfinish.PlayUiActionCraftRefineHideFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_refine_hide_finish");
                        return;
                    case FurnitureitemUicraftsoundfinish.PlayUiActionCraftRefineOreFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_refine_ore_finish");
                        return;
                    case FurnitureitemUicraftsoundfinish.PlayUiActionCraftRefineStoneFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_refine_stone_finish");
                        return;
                    case FurnitureitemUicraftsoundfinish.PlayUiActionCraftRefineWoodFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_refine_wood_finish");
                        return;
                }
                throw new Exception("Cannot marshal type FurnitureitemUicraftsoundfinish");
            }

            public static readonly FurnitureitemUicraftsoundfinishConverter Singleton = new FurnitureitemUicraftsoundfinishConverter();
        }

        internal class FurnitureitemUicraftsoundstartConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(FurnitureitemUicraftsoundstart) || t == typeof(FurnitureitemUicraftsoundstart?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Play_ui_action_craft_flour_start":
                        return FurnitureitemUicraftsoundstart.PlayUiActionCraftFlourStart;
                    case "Play_ui_action_craft_food_firm_start":
                        return FurnitureitemUicraftsoundstart.PlayUiActionCraftFoodFirmStart;
                    case "Play_ui_action_craft_food_fry_start":
                        return FurnitureitemUicraftsoundstart.PlayUiActionCraftFoodFryStart;
                    case "Play_ui_action_craft_food_liquid_start":
                        return FurnitureitemUicraftsoundstart.PlayUiActionCraftFoodLiquidStart;
                    case "Play_ui_action_craft_meat_start":
                        return FurnitureitemUicraftsoundstart.PlayUiActionCraftMeatStart;
                    case "Play_ui_action_craft_refine_fiber_start":
                        return FurnitureitemUicraftsoundstart.PlayUiActionCraftRefineFiberStart;
                    case "Play_ui_action_craft_refine_hide_start":
                        return FurnitureitemUicraftsoundstart.PlayUiActionCraftRefineHideStart;
                    case "Play_ui_action_craft_refine_ore_start":
                        return FurnitureitemUicraftsoundstart.PlayUiActionCraftRefineOreStart;
                    case "Play_ui_action_craft_refine_stone_start":
                        return FurnitureitemUicraftsoundstart.PlayUiActionCraftRefineStoneStart;
                    case "Play_ui_action_craft_refine_wood_start":
                        return FurnitureitemUicraftsoundstart.PlayUiActionCraftRefineWoodStart;
                }
                throw new Exception("Cannot unmarshal type FurnitureitemUicraftsoundstart");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (FurnitureitemUicraftsoundstart)untypedValue;
                switch (value)
                {
                    case FurnitureitemUicraftsoundstart.PlayUiActionCraftFlourStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_flour_start");
                        return;
                    case FurnitureitemUicraftsoundstart.PlayUiActionCraftFoodFirmStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_food_firm_start");
                        return;
                    case FurnitureitemUicraftsoundstart.PlayUiActionCraftFoodFryStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_food_fry_start");
                        return;
                    case FurnitureitemUicraftsoundstart.PlayUiActionCraftFoodLiquidStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_food_liquid_start");
                        return;
                    case FurnitureitemUicraftsoundstart.PlayUiActionCraftMeatStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_meat_start");
                        return;
                    case FurnitureitemUicraftsoundstart.PlayUiActionCraftRefineFiberStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_refine_fiber_start");
                        return;
                    case FurnitureitemUicraftsoundstart.PlayUiActionCraftRefineHideStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_refine_hide_start");
                        return;
                    case FurnitureitemUicraftsoundstart.PlayUiActionCraftRefineOreStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_refine_ore_start");
                        return;
                    case FurnitureitemUicraftsoundstart.PlayUiActionCraftRefineStoneStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_refine_stone_start");
                        return;
                    case FurnitureitemUicraftsoundstart.PlayUiActionCraftRefineWoodStart:
                        serializer.Serialize(writer, "Play_ui_action_craft_refine_wood_start");
                        return;
                }
                throw new Exception("Cannot marshal type FurnitureitemUicraftsoundstart");
            }

            public static readonly FurnitureitemUicraftsoundstartConverter Singleton = new FurnitureitemUicraftsoundstartConverter();
        }

        internal class JournalitemShopsubcategory1Converter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(JournalitemShopsubcategory1) || t == typeof(JournalitemShopsubcategory1?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "journal")
                {
                    return JournalitemShopsubcategory1.Journal;
                }
                throw new Exception("Cannot unmarshal type JournalitemShopsubcategory1");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (JournalitemShopsubcategory1)untypedValue;
                if (value == JournalitemShopsubcategory1.Journal)
                {
                    serializer.Serialize(writer, "journal");
                    return;
                }
                throw new Exception("Cannot marshal type JournalitemShopsubcategory1");
            }

            public static readonly JournalitemShopsubcategory1Converter Singleton = new JournalitemShopsubcategory1Converter();
        }

        internal class ValiditemUnionConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ValiditemUnion) || t == typeof(ValiditemUnion?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<ValiditemElement>(reader);
                        return new ValiditemUnion { ValiditemElement = objectValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<ValiditemElement[]>(reader);
                        return new ValiditemUnion { ValiditemElementArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type ValiditemUnion");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (ValiditemUnion)untypedValue;
                if (value.ValiditemElementArray != null)
                {
                    serializer.Serialize(writer, value.ValiditemElementArray);
                    return;
                }
                if (value.ValiditemElement != null)
                {
                    serializer.Serialize(writer, value.ValiditemElement);
                    return;
                }
                throw new Exception("Cannot marshal type ValiditemUnion");
            }

            public static readonly ValiditemUnionConverter Singleton = new ValiditemUnionConverter();
        }

        internal class LootUnionConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(LootUnion) || t == typeof(LootUnion?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<LootElement>(reader);
                        return new LootUnion { LootElement = objectValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<LootElement[]>(reader);
                        return new LootUnion { LootElementArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type LootUnion");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (LootUnion)untypedValue;
                if (value.LootElementArray != null)
                {
                    serializer.Serialize(writer, value.LootElementArray);
                    return;
                }
                if (value.LootElement != null)
                {
                    serializer.Serialize(writer, value.LootElement);
                    return;
                }
                throw new Exception("Cannot marshal type LootUnion");
            }

            public static readonly LootUnionConverter Singleton = new LootUnionConverter();
        }

        internal class DespawneffectConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Despawneffect) || t == typeof(Despawneffect?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "FX/ClientPrefabs/demount_fx_big":
                        return Despawneffect.FxClientPrefabsDemountFxBig;
                    case "FX/ClientPrefabs/demount_fx_medium":
                        return Despawneffect.FxClientPrefabsDemountFxMedium;
                    case "FX/ClientPrefabs/demount_fx_small":
                        return Despawneffect.FxClientPrefabsDemountFxSmall;
                    case "FX/ClientPrefabs/demount_fx_very_small":
                        return Despawneffect.FxClientPrefabsDemountFxVerySmall;
                }
                throw new Exception("Cannot unmarshal type Despawneffect");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Despawneffect)untypedValue;
                switch (value)
                {
                    case Despawneffect.FxClientPrefabsDemountFxBig:
                        serializer.Serialize(writer, "FX/ClientPrefabs/demount_fx_big");
                        return;
                    case Despawneffect.FxClientPrefabsDemountFxMedium:
                        serializer.Serialize(writer, "FX/ClientPrefabs/demount_fx_medium");
                        return;
                    case Despawneffect.FxClientPrefabsDemountFxSmall:
                        serializer.Serialize(writer, "FX/ClientPrefabs/demount_fx_small");
                        return;
                    case Despawneffect.FxClientPrefabsDemountFxVerySmall:
                        serializer.Serialize(writer, "FX/ClientPrefabs/demount_fx_very_small");
                        return;
                }
                throw new Exception("Cannot marshal type Despawneffect");
            }

            public static readonly DespawneffectConverter Singleton = new DespawneffectConverter();
        }

        internal class DismountbuffConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Dismountbuff) || t == typeof(Dismountbuff?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "DISMOUNTED")
                {
                    return Dismountbuff.Dismounted;
                }
                throw new Exception("Cannot unmarshal type Dismountbuff");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Dismountbuff)untypedValue;
                if (value == Dismountbuff.Dismounted)
                {
                    serializer.Serialize(writer, "DISMOUNTED");
                    return;
                }
                throw new Exception("Cannot marshal type Dismountbuff");
            }

            public static readonly DismountbuffConverter Singleton = new DismountbuffConverter();
        }

        internal class MountShopcategoryConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(MountShopcategory) || t == typeof(MountShopcategory?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "mounts")
                {
                    return MountShopcategory.Mounts;
                }
                throw new Exception("Cannot unmarshal type MountShopcategory");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (MountShopcategory)untypedValue;
                if (value == MountShopcategory.Mounts)
                {
                    serializer.Serialize(writer, "mounts");
                    return;
                }
                throw new Exception("Cannot marshal type MountShopcategory");
            }

            public static readonly MountShopcategoryConverter Singleton = new MountShopcategoryConverter();
        }

        internal class MountShopsubcategory1Converter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(MountShopsubcategory1) || t == typeof(MountShopsubcategory1?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "armoredhorse":
                        return MountShopsubcategory1.Armoredhorse;
                    case "ox":
                        return MountShopsubcategory1.Ox;
                    case "rare_mount":
                        return MountShopsubcategory1.RareMount;
                    case "ridinghorse":
                        return MountShopsubcategory1.Ridinghorse;
                }
                throw new Exception("Cannot unmarshal type MountShopsubcategory1");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (MountShopsubcategory1)untypedValue;
                switch (value)
                {
                    case MountShopsubcategory1.Armoredhorse:
                        serializer.Serialize(writer, "armoredhorse");
                        return;
                    case MountShopsubcategory1.Ox:
                        serializer.Serialize(writer, "ox");
                        return;
                    case MountShopsubcategory1.RareMount:
                        serializer.Serialize(writer, "rare_mount");
                        return;
                    case MountShopsubcategory1.Ridinghorse:
                        serializer.Serialize(writer, "ridinghorse");
                        return;
                }
                throw new Exception("Cannot marshal type MountShopsubcategory1");
            }

            public static readonly MountShopsubcategory1Converter Singleton = new MountShopsubcategory1Converter();
        }

        internal class MountSlottypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(MountSlottype) || t == typeof(MountSlottype?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "mount")
                {
                    return MountSlottype.Mount;
                }
                throw new Exception("Cannot unmarshal type MountSlottype");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (MountSlottype)untypedValue;
                if (value == MountSlottype.Mount)
                {
                    serializer.Serialize(writer, "mount");
                    return;
                }
                throw new Exception("Cannot marshal type MountSlottype");
            }

            public static readonly MountSlottypeConverter Singleton = new MountSlottypeConverter();
        }

        internal class MountUicraftsoundfinishConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(MountUicraftsoundfinish) || t == typeof(MountUicraftsoundfinish?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "Play_mount_mounted":
                        return MountUicraftsoundfinish.PlayMountMounted;
                    case "Play_ui_action_craft_siegemount_finish":
                        return MountUicraftsoundfinish.PlayUiActionCraftSiegemountFinish;
                }
                throw new Exception("Cannot unmarshal type MountUicraftsoundfinish");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (MountUicraftsoundfinish)untypedValue;
                switch (value)
                {
                    case MountUicraftsoundfinish.PlayMountMounted:
                        serializer.Serialize(writer, "Play_mount_mounted");
                        return;
                    case MountUicraftsoundfinish.PlayUiActionCraftSiegemountFinish:
                        serializer.Serialize(writer, "Play_ui_action_craft_siegemount_finish");
                        return;
                }
                throw new Exception("Cannot marshal type MountUicraftsoundfinish");
            }

            public static readonly MountUicraftsoundfinishConverter Singleton = new MountUicraftsoundfinishConverter();
        }

        internal class MountUicraftsoundstartConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(MountUicraftsoundstart) || t == typeof(MountUicraftsoundstart?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "Play_ui_action_craft_mount_start")
                {
                    return MountUicraftsoundstart.PlayUiActionCraftMountStart;
                }
                throw new Exception("Cannot unmarshal type MountUicraftsoundstart");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (MountUicraftsoundstart)untypedValue;
                if (value == MountUicraftsoundstart.PlayUiActionCraftMountStart)
                {
                    serializer.Serialize(writer, "Play_ui_action_craft_mount_start");
                    return;
                }
                throw new Exception("Cannot marshal type MountUicraftsoundstart");
            }

            public static readonly MountUicraftsoundstartConverter Singleton = new MountUicraftsoundstartConverter();
        }

        internal class FluffyCraftresourceConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(FluffyCraftresource) || t == typeof(FluffyCraftresource?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<Replacementitem>(reader);
                        return new FluffyCraftresource { Replacementitem = objectValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<CraftresourceElement[]>(reader);
                        return new FluffyCraftresource { CraftresourceElementArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type FluffyCraftresource");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (FluffyCraftresource)untypedValue;
                if (value.CraftresourceElementArray != null)
                {
                    serializer.Serialize(writer, value.CraftresourceElementArray);
                    return;
                }
                if (value.Replacementitem != null)
                {
                    serializer.Serialize(writer, value.Replacementitem);
                    return;
                }
                throw new Exception("Cannot marshal type FluffyCraftresource");
            }

            public static readonly FluffyCraftresourceConverter Singleton = new FluffyCraftresourceConverter();
        }

        internal class MountspellUnionConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(MountspellUnion) || t == typeof(MountspellUnion?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<MountspellElement>(reader);
                        return new MountspellUnion { MountspellElement = objectValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<MountspellElement[]>(reader);
                        return new MountspellUnion { MountspellElementArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type MountspellUnion");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (MountspellUnion)untypedValue;
                if (value.MountspellElementArray != null)
                {
                    serializer.Serialize(writer, value.MountspellElementArray);
                    return;
                }
                if (value.MountspellElement != null)
                {
                    serializer.Serialize(writer, value.MountspellElement);
                    return;
                }
                throw new Exception("Cannot marshal type MountspellUnion");
            }

            public static readonly MountspellUnionConverter Singleton = new MountspellUnionConverter();
        }

        internal class SpellslotConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Spellslot) || t == typeof(Spellslot?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "armor":
                        return Spellslot.Armor;
                    case "mainhand1":
                        return Spellslot.Mainhand1;
                    case "mainhand2":
                        return Spellslot.Mainhand2;
                    case "offhandormainhand3":
                        return Spellslot.Offhandormainhand3;
                    case "shoes":
                        return Spellslot.Shoes;
                }
                throw new Exception("Cannot unmarshal type Spellslot");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Spellslot)untypedValue;
                switch (value)
                {
                    case Spellslot.Armor:
                        serializer.Serialize(writer, "armor");
                        return;
                    case Spellslot.Mainhand1:
                        serializer.Serialize(writer, "mainhand1");
                        return;
                    case Spellslot.Mainhand2:
                        serializer.Serialize(writer, "mainhand2");
                        return;
                    case Spellslot.Offhandormainhand3:
                        serializer.Serialize(writer, "offhandormainhand3");
                        return;
                    case Spellslot.Shoes:
                        serializer.Serialize(writer, "shoes");
                        return;
                }
                throw new Exception("Cannot marshal type Spellslot");
            }

            public static readonly SpellslotConverter Singleton = new SpellslotConverter();
        }

        internal class SimpleitemDescriptionlocatagConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(SimpleitemDescriptionlocatag) || t == typeof(SimpleitemDescriptionlocatag?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "@CARAVAN_TRADEPACK_FOREST_HEAVY_DESC":
                        return SimpleitemDescriptionlocatag.CaravanTradepackForestHeavyDesc;
                    case "@CARAVAN_TRADEPACK_FOREST_LIGHT_DESC":
                        return SimpleitemDescriptionlocatag.CaravanTradepackForestLightDesc;
                    case "@CARAVAN_TRADEPACK_FOREST_MEDIUM_DESC":
                        return SimpleitemDescriptionlocatag.CaravanTradepackForestMediumDesc;
                    case "@CARAVAN_TRADEPACK_HIGHLAND_HEAVY_DESC":
                        return SimpleitemDescriptionlocatag.CaravanTradepackHighlandHeavyDesc;
                    case "@CARAVAN_TRADEPACK_HIGHLAND_LIGHT_DESC":
                        return SimpleitemDescriptionlocatag.CaravanTradepackHighlandLightDesc;
                    case "@CARAVAN_TRADEPACK_HIGHLAND_MEDIUM_DESC":
                        return SimpleitemDescriptionlocatag.CaravanTradepackHighlandMediumDesc;
                    case "@CARAVAN_TRADEPACK_MOUNTAIN_HEAVY_DESC":
                        return SimpleitemDescriptionlocatag.CaravanTradepackMountainHeavyDesc;
                    case "@CARAVAN_TRADEPACK_MOUNTAIN_LIGHT_DESC":
                        return SimpleitemDescriptionlocatag.CaravanTradepackMountainLightDesc;
                    case "@CARAVAN_TRADEPACK_MOUNTAIN_MEDIUM_DESC":
                        return SimpleitemDescriptionlocatag.CaravanTradepackMountainMediumDesc;
                    case "@CARAVAN_TRADEPACK_STEPPE_HEAVY_DESC":
                        return SimpleitemDescriptionlocatag.CaravanTradepackSteppeHeavyDesc;
                    case "@CARAVAN_TRADEPACK_STEPPE_LIGHT_DESC":
                        return SimpleitemDescriptionlocatag.CaravanTradepackSteppeLightDesc;
                    case "@CARAVAN_TRADEPACK_STEPPE_MEDIUM_DESC":
                        return SimpleitemDescriptionlocatag.CaravanTradepackSteppeMediumDesc;
                    case "@CARAVAN_TRADEPACK_SWAMP_HEAVY_DESC":
                        return SimpleitemDescriptionlocatag.CaravanTradepackSwampHeavyDesc;
                    case "@CARAVAN_TRADEPACK_SWAMP_LIGHT_DESC":
                        return SimpleitemDescriptionlocatag.CaravanTradepackSwampLightDesc;
                    case "@CARAVAN_TRADEPACK_SWAMP_MEDIUM_DESC":
                        return SimpleitemDescriptionlocatag.CaravanTradepackSwampMediumDesc;
                    case "@EXPEDITION_TOKEN_DESC":
                        return SimpleitemDescriptionlocatag.ExpeditionTokenDesc;
                    case "@ITEMS_ARTEFACT_WEAPON_DESC":
                        return SimpleitemDescriptionlocatag.ItemsArtefactWeaponDesc;
                    case "@ITEMS_FISHSAUCE_DESC":
                        return SimpleitemDescriptionlocatag.ItemsFishsauceDesc;
                }
                throw new Exception("Cannot unmarshal type SimpleitemDescriptionlocatag");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (SimpleitemDescriptionlocatag)untypedValue;
                switch (value)
                {
                    case SimpleitemDescriptionlocatag.CaravanTradepackForestHeavyDesc:
                        serializer.Serialize(writer, "@CARAVAN_TRADEPACK_FOREST_HEAVY_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.CaravanTradepackForestLightDesc:
                        serializer.Serialize(writer, "@CARAVAN_TRADEPACK_FOREST_LIGHT_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.CaravanTradepackForestMediumDesc:
                        serializer.Serialize(writer, "@CARAVAN_TRADEPACK_FOREST_MEDIUM_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.CaravanTradepackHighlandHeavyDesc:
                        serializer.Serialize(writer, "@CARAVAN_TRADEPACK_HIGHLAND_HEAVY_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.CaravanTradepackHighlandLightDesc:
                        serializer.Serialize(writer, "@CARAVAN_TRADEPACK_HIGHLAND_LIGHT_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.CaravanTradepackHighlandMediumDesc:
                        serializer.Serialize(writer, "@CARAVAN_TRADEPACK_HIGHLAND_MEDIUM_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.CaravanTradepackMountainHeavyDesc:
                        serializer.Serialize(writer, "@CARAVAN_TRADEPACK_MOUNTAIN_HEAVY_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.CaravanTradepackMountainLightDesc:
                        serializer.Serialize(writer, "@CARAVAN_TRADEPACK_MOUNTAIN_LIGHT_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.CaravanTradepackMountainMediumDesc:
                        serializer.Serialize(writer, "@CARAVAN_TRADEPACK_MOUNTAIN_MEDIUM_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.CaravanTradepackSteppeHeavyDesc:
                        serializer.Serialize(writer, "@CARAVAN_TRADEPACK_STEPPE_HEAVY_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.CaravanTradepackSteppeLightDesc:
                        serializer.Serialize(writer, "@CARAVAN_TRADEPACK_STEPPE_LIGHT_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.CaravanTradepackSteppeMediumDesc:
                        serializer.Serialize(writer, "@CARAVAN_TRADEPACK_STEPPE_MEDIUM_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.CaravanTradepackSwampHeavyDesc:
                        serializer.Serialize(writer, "@CARAVAN_TRADEPACK_SWAMP_HEAVY_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.CaravanTradepackSwampLightDesc:
                        serializer.Serialize(writer, "@CARAVAN_TRADEPACK_SWAMP_LIGHT_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.CaravanTradepackSwampMediumDesc:
                        serializer.Serialize(writer, "@CARAVAN_TRADEPACK_SWAMP_MEDIUM_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.ExpeditionTokenDesc:
                        serializer.Serialize(writer, "@EXPEDITION_TOKEN_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.ItemsArtefactWeaponDesc:
                        serializer.Serialize(writer, "@ITEMS_ARTEFACT_WEAPON_DESC");
                        return;
                    case SimpleitemDescriptionlocatag.ItemsFishsauceDesc:
                        serializer.Serialize(writer, "@ITEMS_FISHSAUCE_DESC");
                        return;
                }
                throw new Exception("Cannot marshal type SimpleitemDescriptionlocatag");
            }

            public static readonly SimpleitemDescriptionlocatagConverter Singleton = new SimpleitemDescriptionlocatagConverter();
        }

    internal class SimpleitemCraftingrequirementsConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Craftingrequirements) || t == typeof(Craftingrequirements?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<Craftingrequirement>(reader);
                        return new Craftingrequirements { Craftingrequirement = objectValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<Craftingrequirement[]>(reader);
                        return new Craftingrequirements { CraftingrequirementArrayArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type SimpleitemCraftingrequirements");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (Craftingrequirements)untypedValue;
                if (value.CraftingrequirementArrayArray != null)
                {
                    serializer.Serialize(writer, value.CraftingrequirementArrayArray);
                    return;
                }
                if (value.Craftingrequirement != null)
                {
                    serializer.Serialize(writer, value.Craftingrequirement);
                    return;
                }
                throw new Exception("Cannot marshal type SimpleitemCraftingrequirements");
            }

            public static readonly SimpleitemCraftingrequirementsConverter Singleton = new SimpleitemCraftingrequirementsConverter();
        }

        internal class BuildingfilterConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Buildingfilter) || t == typeof(Buildingfilter?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "FOREST_GREEN_FACTION_TRADER":
                        return Buildingfilter.ForestGreenFactionTrader;
                    case "HIGHLAND_GREEN_FACTION_TRADER":
                        return Buildingfilter.HighlandGreenFactionTrader;
                    case "MOUNTAIN_GREEN_FACTION_TRADER":
                        return Buildingfilter.MountainGreenFactionTrader;
                    case "STEPPE_GREEN_FACTION_TRADER":
                        return Buildingfilter.SteppeGreenFactionTrader;
                    case "SWAMP_GREEN_FACTION_TRADER":
                        return Buildingfilter.SwampGreenFactionTrader;
                }
                throw new Exception("Cannot unmarshal type Buildingfilter");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Buildingfilter)untypedValue;
                switch (value)
                {
                    case Buildingfilter.ForestGreenFactionTrader:
                        serializer.Serialize(writer, "FOREST_GREEN_FACTION_TRADER");
                        return;
                    case Buildingfilter.HighlandGreenFactionTrader:
                        serializer.Serialize(writer, "HIGHLAND_GREEN_FACTION_TRADER");
                        return;
                    case Buildingfilter.MountainGreenFactionTrader:
                        serializer.Serialize(writer, "MOUNTAIN_GREEN_FACTION_TRADER");
                        return;
                    case Buildingfilter.SteppeGreenFactionTrader:
                        serializer.Serialize(writer, "STEPPE_GREEN_FACTION_TRADER");
                        return;
                    case Buildingfilter.SwampGreenFactionTrader:
                        serializer.Serialize(writer, "SWAMP_GREEN_FACTION_TRADER");
                        return;
                }
                throw new Exception("Cannot marshal type Buildingfilter");
            }

            public static readonly BuildingfilterConverter Singleton = new BuildingfilterConverter();
        }

        internal class TentacledCraftresourceConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(TentacledCraftresource) || t == typeof(TentacledCraftresource?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<CraftresourceElement>(reader);
                        return new TentacledCraftresource { CraftresourceElement = objectValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<CraftresourceElement[]>(reader);
                        return new TentacledCraftresource { ReplacementitemArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type TentacledCraftresource");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (TentacledCraftresource)untypedValue;
                if (value.ReplacementitemArray != null)
                {
                    serializer.Serialize(writer, value.ReplacementitemArray);
                    return;
                }
                if (value.CraftresourceElement != null)
                {
                    serializer.Serialize(writer, value.CraftresourceElement);
                    return;
                }
                throw new Exception("Cannot marshal type TentacledCraftresource");
            }

            public static readonly TentacledCraftresourceConverter Singleton = new TentacledCraftresourceConverter();
        }

        internal class AttacktypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Attacktype) || t == typeof(Attacktype?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "magic":
                        return Attacktype.Magic;
                    case "melee":
                        return Attacktype.Melee;
                    case "ranged":
                        return Attacktype.Ranged;
                    case "tools":
                        return Attacktype.Tools;
                }
                throw new Exception("Cannot unmarshal type Attacktype");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Attacktype)untypedValue;
                switch (value)
                {
                    case Attacktype.Magic:
                        serializer.Serialize(writer, "magic");
                        return;
                    case Attacktype.Melee:
                        serializer.Serialize(writer, "melee");
                        return;
                    case Attacktype.Ranged:
                        serializer.Serialize(writer, "ranged");
                        return;
                    case Attacktype.Tools:
                        serializer.Serialize(writer, "tools");
                        return;
                }
                throw new Exception("Cannot marshal type Attacktype");
            }

            public static readonly AttacktypeConverter Singleton = new AttacktypeConverter();
        }

        internal class Shopsubcategory1EnumConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Shopsubcategory1Enum) || t == typeof(Shopsubcategory1Enum?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "arcanestaff":
                        return Shopsubcategory1Enum.Arcanestaff;
                    case "axe":
                        return Shopsubcategory1Enum.Axe;
                    case "bow":
                        return Shopsubcategory1Enum.Bow;
                    case "crossbow":
                        return Shopsubcategory1Enum.Crossbow;
                    case "cursestaff":
                        return Shopsubcategory1Enum.Cursestaff;
                    case "dagger":
                        return Shopsubcategory1Enum.Dagger;
                    case "demolitionhammer":
                        return Shopsubcategory1Enum.Demolitionhammer;
                    case "firestaff":
                        return Shopsubcategory1Enum.Firestaff;
                    case "fishing":
                        return Shopsubcategory1Enum.Fishing;
                    case "froststaff":
                        return Shopsubcategory1Enum.Froststaff;
                    case "hammer":
                        return Shopsubcategory1Enum.Hammer;
                    case "holystaff":
                        return Shopsubcategory1Enum.Holystaff;
                    case "mace":
                        return Shopsubcategory1Enum.Mace;
                    case "naturestaff":
                        return Shopsubcategory1Enum.Naturestaff;
                    case "pickaxe":
                        return Shopsubcategory1Enum.Pickaxe;
                    case "quarterstaff":
                        return Shopsubcategory1Enum.Quarterstaff;
                    case "sickle":
                        return Shopsubcategory1Enum.Sickle;
                    case "skinningknife":
                        return Shopsubcategory1Enum.Skinningknife;
                    case "spear":
                        return Shopsubcategory1Enum.Spear;
                    case "stonehammer":
                        return Shopsubcategory1Enum.Stonehammer;
                    case "sword":
                        return Shopsubcategory1Enum.Sword;
                    case "woodaxe":
                        return Shopsubcategory1Enum.Woodaxe;
                }
                throw new Exception("Cannot unmarshal type Shopsubcategory1Enum");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Shopsubcategory1Enum)untypedValue;
                switch (value)
                {
                    case Shopsubcategory1Enum.Arcanestaff:
                        serializer.Serialize(writer, "arcanestaff");
                        return;
                    case Shopsubcategory1Enum.Axe:
                        serializer.Serialize(writer, "axe");
                        return;
                    case Shopsubcategory1Enum.Bow:
                        serializer.Serialize(writer, "bow");
                        return;
                    case Shopsubcategory1Enum.Crossbow:
                        serializer.Serialize(writer, "crossbow");
                        return;
                    case Shopsubcategory1Enum.Cursestaff:
                        serializer.Serialize(writer, "cursestaff");
                        return;
                    case Shopsubcategory1Enum.Dagger:
                        serializer.Serialize(writer, "dagger");
                        return;
                    case Shopsubcategory1Enum.Demolitionhammer:
                        serializer.Serialize(writer, "demolitionhammer");
                        return;
                    case Shopsubcategory1Enum.Firestaff:
                        serializer.Serialize(writer, "firestaff");
                        return;
                    case Shopsubcategory1Enum.Fishing:
                        serializer.Serialize(writer, "fishing");
                        return;
                    case Shopsubcategory1Enum.Froststaff:
                        serializer.Serialize(writer, "froststaff");
                        return;
                    case Shopsubcategory1Enum.Hammer:
                        serializer.Serialize(writer, "hammer");
                        return;
                    case Shopsubcategory1Enum.Holystaff:
                        serializer.Serialize(writer, "holystaff");
                        return;
                    case Shopsubcategory1Enum.Mace:
                        serializer.Serialize(writer, "mace");
                        return;
                    case Shopsubcategory1Enum.Naturestaff:
                        serializer.Serialize(writer, "naturestaff");
                        return;
                    case Shopsubcategory1Enum.Pickaxe:
                        serializer.Serialize(writer, "pickaxe");
                        return;
                    case Shopsubcategory1Enum.Quarterstaff:
                        serializer.Serialize(writer, "quarterstaff");
                        return;
                    case Shopsubcategory1Enum.Sickle:
                        serializer.Serialize(writer, "sickle");
                        return;
                    case Shopsubcategory1Enum.Skinningknife:
                        serializer.Serialize(writer, "skinningknife");
                        return;
                    case Shopsubcategory1Enum.Spear:
                        serializer.Serialize(writer, "spear");
                        return;
                    case Shopsubcategory1Enum.Stonehammer:
                        serializer.Serialize(writer, "stonehammer");
                        return;
                    case Shopsubcategory1Enum.Sword:
                        serializer.Serialize(writer, "sword");
                        return;
                    case Shopsubcategory1Enum.Woodaxe:
                        serializer.Serialize(writer, "woodaxe");
                        return;
                }
                throw new Exception("Cannot marshal type Shopsubcategory1Enum");
            }

            public static readonly Shopsubcategory1EnumConverter Singleton = new Shopsubcategory1EnumConverter();
        }

        internal class FxbonenameConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Fxbonename) || t == typeof(Fxbonename?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "LeftArm_3":
                        return Fxbonename.LeftArm3;
                    case "RightArm_3":
                        return Fxbonename.RightArm3;
                }
                throw new Exception("Cannot unmarshal type Fxbonename");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Fxbonename)untypedValue;
                switch (value)
                {
                    case Fxbonename.LeftArm3:
                        serializer.Serialize(writer, "LeftArm_3");
                        return;
                    case Fxbonename.RightArm3:
                        serializer.Serialize(writer, "RightArm_3");
                        return;
                }
                throw new Exception("Cannot marshal type Fxbonename");
            }

            public static readonly FxbonenameConverter Singleton = new FxbonenameConverter();
        }

        internal class FxboneoffsetConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Fxboneoffset) || t == typeof(Fxboneoffset?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "0.2 -0.227 0.135":
                        return Fxboneoffset.The0202270135;
                    case "1.33 0.11 -0.43":
                        return Fxboneoffset.The133011043;
                }
                throw new Exception("Cannot unmarshal type Fxboneoffset");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Fxboneoffset)untypedValue;
                switch (value)
                {
                    case Fxboneoffset.The0202270135:
                        serializer.Serialize(writer, "0.2 -0.227 0.135");
                        return;
                    case Fxboneoffset.The133011043:
                        serializer.Serialize(writer, "1.33 0.11 -0.43");
                        return;
                }
                throw new Exception("Cannot marshal type Fxboneoffset");
            }

            public static readonly FxboneoffsetConverter Singleton = new FxboneoffsetConverter();
        }

        internal class CanharvestResourcetypeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(CanharvestResourcetype) || t == typeof(CanharvestResourcetype?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "FIBER":
                        return CanharvestResourcetype.Fiber;
                    case "HIDE":
                        return CanharvestResourcetype.Hide;
                    case "ORE":
                        return CanharvestResourcetype.Ore;
                    case "ROCK":
                        return CanharvestResourcetype.Rock;
                    case "WOOD":
                        return CanharvestResourcetype.Wood;
                }
                throw new Exception("Cannot unmarshal type CanharvestResourcetype");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (CanharvestResourcetype)untypedValue;
                switch (value)
                {
                    case CanharvestResourcetype.Fiber:
                        serializer.Serialize(writer, "FIBER");
                        return;
                    case CanharvestResourcetype.Hide:
                        serializer.Serialize(writer, "HIDE");
                        return;
                    case CanharvestResourcetype.Ore:
                        serializer.Serialize(writer, "ORE");
                        return;
                    case CanharvestResourcetype.Rock:
                        serializer.Serialize(writer, "ROCK");
                        return;
                    case CanharvestResourcetype.Wood:
                        serializer.Serialize(writer, "WOOD");
                        return;
                }
                throw new Exception("Cannot marshal type CanharvestResourcetype");
            }

            public static readonly CanharvestResourcetypeConverter Singleton = new CanharvestResourcetypeConverter();
        }

        internal class StickyCraftspellConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(StickyCraftspell) || t == typeof(StickyCraftspell?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<PurpleCraftspell>(reader);
                        return new StickyCraftspell { PurpleCraftspell = objectValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<FluffyCraftspell[]>(reader);
                        return new StickyCraftspell { FluffyCraftspellArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type StickyCraftspell");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (StickyCraftspell)untypedValue;
                if (value.FluffyCraftspellArray != null)
                {
                    serializer.Serialize(writer, value.FluffyCraftspellArray);
                    return;
                }
                if (value.PurpleCraftspell != null)
                {
                    serializer.Serialize(writer, value.PurpleCraftspell);
                    return;
                }
                throw new Exception("Cannot marshal type StickyCraftspell");
            }

            public static readonly StickyCraftspellConverter Singleton = new StickyCraftspellConverter();
        }

        internal class TagConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Tag) || t == typeof(Tag?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "A":
                        return Tag.A;
                    case "B":
                        return Tag.B;
                    case "C":
                        return Tag.C;
                    case "D":
                        return Tag.D;
                    case "E":
                        return Tag.E;
                    case "F":
                        return Tag.F;
                    case "G":
                        return Tag.G;
                    case "H":
                        return Tag.H;
                    case "I":
                        return Tag.I;
                }
                throw new Exception("Cannot unmarshal type Tag");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Tag)untypedValue;
                switch (value)
                {
                    case Tag.A:
                        serializer.Serialize(writer, "A");
                        return;
                    case Tag.B:
                        serializer.Serialize(writer, "B");
                        return;
                    case Tag.C:
                        serializer.Serialize(writer, "C");
                        return;
                    case Tag.D:
                        serializer.Serialize(writer, "D");
                        return;
                    case Tag.E:
                        serializer.Serialize(writer, "E");
                        return;
                    case Tag.F:
                        serializer.Serialize(writer, "F");
                        return;
                    case Tag.G:
                        serializer.Serialize(writer, "G");
                        return;
                    case Tag.H:
                        serializer.Serialize(writer, "H");
                        return;
                    case Tag.I:
                        serializer.Serialize(writer, "I");
                        return;
                }
                throw new Exception("Cannot marshal type Tag");
            }

            public static readonly TagConverter Singleton = new TagConverter();
        }

        internal class ProjectileUnionConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(ProjectileUnion) || t == typeof(ProjectileUnion?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.StartObject:
                        var objectValue = serializer.Deserialize<ProjectileElement>(reader);
                        return new ProjectileUnion { ProjectileElement = objectValue };
                    case JsonToken.StartArray:
                        var arrayValue = serializer.Deserialize<ProjectileElement[]>(reader);
                        return new ProjectileUnion { ProjectileElementArray = arrayValue };
                }
                throw new Exception("Cannot unmarshal type ProjectileUnion");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (ProjectileUnion)untypedValue;
                if (value.ProjectileElementArray != null)
                {
                    serializer.Serialize(writer, value.ProjectileElementArray);
                    return;
                }
                if (value.ProjectileElement != null)
                {
                    serializer.Serialize(writer, value.ProjectileElement);
                    return;
                }
                throw new Exception("Cannot marshal type ProjectileUnion");
            }

            public static readonly ProjectileUnionConverter Singleton = new ProjectileUnionConverter();
        }

        internal class TsocketConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Tsocket) || t == typeof(Tsocket?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                if (value == "damage")
                {
                    return Tsocket.Damage;
                }
                throw new Exception("Cannot unmarshal type Tsocket");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Tsocket)untypedValue;
                if (value == Tsocket.Damage)
                {
                    serializer.Serialize(writer, "damage");
                    return;
                }
                throw new Exception("Cannot marshal type Tsocket");
            }

            public static readonly TsocketConverter Singleton = new TsocketConverter();
        }

        internal class PrefabConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Prefab) || t == typeof(Prefab?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "FX/ClientPrefabs/fx_spell_magic_projectile_arcane":
                        return Prefab.FxClientPrefabsFxSpellMagicProjectileArcane;
                    case "FX/ClientPrefabs/fx_spell_magic_projectile_cursed":
                        return Prefab.FxClientPrefabsFxSpellMagicProjectileCursed;
                    case "FX/ClientPrefabs/fx_spell_magic_projectile_fire":
                        return Prefab.FxClientPrefabsFxSpellMagicProjectileFire;
                    case "FX/ClientPrefabs/fx_spell_magic_projectile_holy":
                        return Prefab.FxClientPrefabsFxSpellMagicProjectileHoly;
                    case "FX/ClientPrefabs/fx_spell_magic_projectile_ice":
                        return Prefab.FxClientPrefabsFxSpellMagicProjectileIce;
                    case "FX/ClientPrefabs/fx_spell_magic_projectile_nature":
                        return Prefab.FxClientPrefabsFxSpellMagicProjectileNature;
                    case "FX/ClientPrefabs/fx_spell_vanity_portal_autoattack_projectile_01":
                        return Prefab.FxClientPrefabsFxSpellVanityPortalAutoattackProjectile01;
                    case "Prefabs/Vfx/Projectiles/Arrow":
                        return Prefab.PrefabsVfxProjectilesArrow;
                }
                throw new Exception("Cannot unmarshal type Prefab");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Prefab)untypedValue;
                switch (value)
                {
                    case Prefab.FxClientPrefabsFxSpellMagicProjectileArcane:
                        serializer.Serialize(writer, "FX/ClientPrefabs/fx_spell_magic_projectile_arcane");
                        return;
                    case Prefab.FxClientPrefabsFxSpellMagicProjectileCursed:
                        serializer.Serialize(writer, "FX/ClientPrefabs/fx_spell_magic_projectile_cursed");
                        return;
                    case Prefab.FxClientPrefabsFxSpellMagicProjectileFire:
                        serializer.Serialize(writer, "FX/ClientPrefabs/fx_spell_magic_projectile_fire");
                        return;
                    case Prefab.FxClientPrefabsFxSpellMagicProjectileHoly:
                        serializer.Serialize(writer, "FX/ClientPrefabs/fx_spell_magic_projectile_holy");
                        return;
                    case Prefab.FxClientPrefabsFxSpellMagicProjectileIce:
                        serializer.Serialize(writer, "FX/ClientPrefabs/fx_spell_magic_projectile_ice");
                        return;
                    case Prefab.FxClientPrefabsFxSpellMagicProjectileNature:
                        serializer.Serialize(writer, "FX/ClientPrefabs/fx_spell_magic_projectile_nature");
                        return;
                    case Prefab.FxClientPrefabsFxSpellVanityPortalAutoattackProjectile01:
                        serializer.Serialize(writer, "FX/ClientPrefabs/fx_spell_vanity_portal_autoattack_projectile_01");
                        return;
                    case Prefab.PrefabsVfxProjectilesArrow:
                        serializer.Serialize(writer, "Prefabs/Vfx/Projectiles/Arrow");
                        return;
                }
                throw new Exception("Cannot marshal type Prefab");
            }

            public static readonly PrefabConverter Singleton = new PrefabConverter();
        }

        internal class StartsocketConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(Startsocket) || t == typeof(Startsocket?);

            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null) return null;
                var value = serializer.Deserialize<string>(reader);
                switch (value)
                {
                    case "mainhandprojectile":
                        return Startsocket.Mainhandprojectile;
                    case "offhandprojectile":
                        return Startsocket.Offhandprojectile;
                }
                throw new Exception("Cannot unmarshal type Startsocket");
            }

            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                if (untypedValue == null)
                {
                    serializer.Serialize(writer, null);
                    return;
                }
                var value = (Startsocket)untypedValue;
                switch (value)
                {
                    case Startsocket.Mainhandprojectile:
                        serializer.Serialize(writer, "mainhandprojectile");
                        return;
                    case Startsocket.Offhandprojectile:
                        serializer.Serialize(writer, "offhandprojectile");
                        return;
                }
                throw new Exception("Cannot marshal type Startsocket");
            }

            public static readonly StartsocketConverter Singleton = new StartsocketConverter();
        }
    }
