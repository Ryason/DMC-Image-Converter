namespace DMCConverter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadImageButon = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.UserImageBox = new System.Windows.Forms.PictureBox();
            this.ImageTitleText = new System.Windows.Forms.Label();
            this.dmcPaletteBox = new System.Windows.Forms.CheckedListBox();
            this.paletteCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConvertButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.UserImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadImageButon
            // 
            this.LoadImageButon.Location = new System.Drawing.Point(164, 151);
            this.LoadImageButon.Name = "LoadImageButon";
            this.LoadImageButon.Size = new System.Drawing.Size(75, 23);
            this.LoadImageButon.TabIndex = 0;
            this.LoadImageButon.Text = "Load Image";
            this.LoadImageButon.UseVisualStyleBackColor = true;
            this.LoadImageButon.Click += new System.EventHandler(this.LoadImageButon_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // UserImageBox
            // 
            this.UserImageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.UserImageBox.Location = new System.Drawing.Point(141, 25);
            this.UserImageBox.MaximumSize = new System.Drawing.Size(100, 100);
            this.UserImageBox.MinimumSize = new System.Drawing.Size(120, 120);
            this.UserImageBox.Name = "UserImageBox";
            this.UserImageBox.Size = new System.Drawing.Size(120, 120);
            this.UserImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.UserImageBox.TabIndex = 1;
            this.UserImageBox.TabStop = false;
            // 
            // ImageTitleText
            // 
            this.ImageTitleText.AutoSize = true;
            this.ImageTitleText.Location = new System.Drawing.Point(138, 9);
            this.ImageTitleText.Name = "ImageTitleText";
            this.ImageTitleText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ImageTitleText.Size = new System.Drawing.Size(92, 13);
            this.ImageTitleText.TabIndex = 2;
            this.ImageTitleText.Text = "Image To Convert";
            this.ImageTitleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dmcPaletteBox
            // 
            this.dmcPaletteBox.CheckOnClick = true;
            this.dmcPaletteBox.FormattingEnabled = true;
            this.dmcPaletteBox.Items.AddRange(new object[] {
            "#cf0053,150",
            "#ffcbd7,151",
            "#e1a1a1,152",
            "#eac5eb,153",
            "#4b233a,154",
            "#9774b6,155",
            "#8577b4,156",
            "#b5b8ea,157",
            "#393068,158",
            "#bcb5de,159",
            "#8178a9,160",
            "#60568b,161",
            "#cae7f0,162",
            "#557a60,163",
            "#bae4b6,164",
            "#e1f477,165",
            "#adc238,166",
            "#855d31,167",
            "#b1aeb7,168",
            "#827d7d,169",
            "#9442a7,208",
            "#ba72c6,209",
            "#d49fe1,210",
            "#e5bded,211",
            "#792631,221",
            "#bb6864,223",
            "#e2a598,224",
            "#f8d9cd,225",
            "#6c3116,300",
            "#aa5237,301",
            "#655935,3011",
            "#8b7b4e,3012",
            "#afa97b,3013",
            "#50403b,3021",
            "#848274,3022",
            "#a29b86,3023",
            "#beb8ac,3024",
            "#423014,3031",
            "#9d8868,3032",
            "#dbc7ad,3033",
            "#a10c39,304",
            "#866a76,3041",
            "#af98a0,3042",
            "#af8152,3045",
            "#ceb074,3046",
            "#ead8ab,3047",
            "#4c4c1e,3051",
            "#787e5c,3052",
            "#999d75,3053",
            "#ba7056,3064",
            "#fde949,307",
            "#d2d2ca,3072",
            "#fcf6b6,3078",
            "#ba2044,309",
            "#000000,310",
            "#002a64,311",
            "#1f3279,312",
            "#7d4246,315",
            "#bc757f,316",
            "#6d6469,317",
            "#999b9d,318",
            "#3a553b,319",
            "#608c59,320",
            "#bd1136,321",
            "#3a609d,322",
            "#ac1c37,326",
            "#5e0f77,327",
            "#adcde7,3325",
            "#f9979c,3326",
            "#be444a,3328",
            "#6e2e9b,333",
            "#6085b8,334",
            "#fd6b4f,3340",
            "#fd8e78,3341",
            "#40552e,3345",
            "#56743b,3346",
            "#6d9646,3347",
            "#bedf74,3348",
            "#d63d57,335",
            "#aa3949,3350",
            "#efa5ac,3354",
            "#0c275e,336",
            "#49523c,3362",
            "#617451,3363",
            "#8e9b6d,3364",
            "#36220e,3371",
            "#996dc3,340",
            "#a39ad7,341",
            "#ab1b33,347",
            "#c62c38,349",
            "#de3f40,350",
            "#ed625b,351",
            "#f78372,352",
            "#fdb4a1,353",
            "#97382b,355",
            "#be5c4b,356",
            "#d94c9d,3607",
            "#ec81be,3608",
            "#f6b0df,3609",
            "#446b45,367",
            "#7fc66d,368",
            "#79263b,3685",
            "#b5455d,3687",
            "#dc7c86,3688",
            "#f8bbc8,3689",
            "#cdefa6,369",
            "#917245,370",
            "#f2494f,3705",
            "#fd6e70,3706",
            "#fda0ae,3708",
            "#9f8352,371",
            "#d95d5d,3712",
            "#fdd5d0,3713",
            "#fcafb9,3716",
            "#ad9564,372",
            "#933b3d,3721",
            "#a04b4c,3722",
            "#95565c,3726",
            "#da9ea6,3727",
            "#c34c5c,3731",
            "#ea7e86,3733",
            "#71535d,3740",
            "#cfc2c9,3743",
            "#844ab5,3746",
            "#d0c5ec,3747",
            "#1d4552,3750",
            "#bac9cc,3752",
            "#d9e6ec,3753",
            "#81a5d8,3755",
            "#e9f4fa,3756",
            "#467293,3760",
            "#b1d0df,3761",
            "#175e78,3765",
            "#4b8aa1,3766",
            "#4c605f,3768",
            "#fef1d8,3770",
            "#e8ac9b,3771",
            "#995744,3772",
            "#f3cfb4,3774",
            "#c96444,3776",
            "#922f25,3777",
            "#d2705c,3778",
            "#f2ab95,3779",
            "#593f2b,3781",
            "#b69d80,3782",
            "#62524c,3787",
            "#6d5a4b,3790",
            "#39393d,3799",
            "#e4353d,3801",
            "#672a33,3802",
            "#872a43,3803",
            "#ce2b63,3804",
            "#df3c73,3805",
            "#f15a91,3806",
            "#4b599e,3807",
            "#03535c,3808",
            "#136a75,3809",
            "#2d8d98,3810",
            "#a8e2e5,3811",
            "#07a184,3812",
            "#86c3ab,3813",
            "#0b8673,3814",
            "#437259,3815",
            "#60937a,3816",
            "#81c6a4,3817",
            "#005d2e,3818",
            "#ccc959,3819",
            "#dba53e,3820",
            "#ebbb52,3821",
            "#f7d169,3822",
            "#fef5cd,3823",
            "#fcae99,3824",
            "#fea370,3825",
            "#b16633,3826",
            "#eaa664,3827",
            "#aa7c43,3828",
            "#a7671d,3829",
            "#a94138,3830",
            "#c12b52,3831",
            "#e36370,3832",
            "#ea8b96,3833",
            "#6a2258,3834",
            "#924d78,3835",
            "#c597b9,3836",
            "#8a2a8f,3837",
            "#606bad,3838",
            "#7a7ec5,3839",
            "#b2bdea,3840",
            "#d9eaf2,3841",
            "#06506a,3842",
            "#28a3de,3843",
            "#1f7fa0,3844",
            "#2badd1,3845",
            "#5eccec,3846",
            "#186358,3847",
            "#207e72,3848",
            "#35b193,3849",
            "#208b46,3850",
            "#61bb84,3851",
            "#e3a730,3852",
            "#ef8125,3853",
            "#fbac56,3854",
            "#fddfa0,3855",
            "#fdbe8e,3856",
            "#6a2f26,3857",
            "#803a32,3858",
            "#ba7a6c,3859",
            "#896362,3860",
            "#ac8583,3861",
            "#6e492a,3862",
            "#94725d,3863",
            "#c9aa92,3864",
            "#fffdf9,3865",
            "#f0e6d7,3866",
            "#813718,400",
            "#ef9e74,402",
            "#b77159,407",
            "#4a4749,413",
            "#766e72,414",
            "#b8b9bd,415",
            "#855a30,420",
            "#c99a67,422",
            "#73421e,433",
            "#8f5332,434",
            "#a96538,435",
            "#c78559,436",
            "#daa26f,437",
            "#f5bc13,444",
            "#fcf999,445",
            "#887773,451",
            "#ad9994,452",
            "#ccb8aa,453",
            "#5b6533,469",
            "#72813e,470",
            "#9eb357,471",
            "#d1de75,472",
            "#970b2c,498",
            "#1d362a,500",
            "#2f5446,501",
            "#57826e,502",
            "#89b89f,503",
            "#ceddc1,505",
            "#216285,517",
            "#50819c,518",
            "#94b7cb,519",
            "#384526,520",
            "#808b6e,522",
            "#959f7a,523",
            "#aea78e,524",
            "#4b4b49,535",
            "#ead0b5,543",
            "#580e5c,550",
            "#902f99,552",
            "#a449ac,553",
            "#dc9cde,554",
            "#285e48,561",
            "#3b8c5a,562",
            "#6ed39a,563",
            "#95e4af,564",
            "#355f0b,580",
            "#838a29,581",
            "#52adab,597",
            "#97d8d3,598",
            "#bf1c48,600",
            "#c62a53,601",
            "#d63f68,602",
            "#ed5d84,603",
            "#f793b2,604",
            "#fbacc4,605",
            "#f70f00,606",
            "#fd480c,608",
            "#6b5039,610",
            "#7c5f46,611",
            "#a6885e,612",
            "#b99f72,613",
            "#7f4232,632",
            "#817868,640",
            "#958d79,642",
            "#c4bea6,644",
            "#5d5d54,645",
            "#6b6860,646",
            "#908e85,647",
            "#a7a69f,648",
            "#ce1b33,666",
            "#ecbf7d,676",
            "#f2dc9f,677",
            "#b07b46,680",
            "#075b26,699",
            "#076c34,700",
            "#217c36,701",
            "#379130,702",
            "#63b330,703",
            "#88c53a,704",
            "#f6efda,712",
            "#cb2089,718",
            "#c83a24,720",
            "#f46440,721",
            "#f98756,722",
            "#f9c15b,725",
            "#fddb63,726",
            "#fde98b,727",
            "#f2ae3f,728",
            "#ce9657,729",
            "#63520b,730",
            "#725c0c,732",
            "#a78a44,733",
            "#bb9c54,734",
            "#e2b783,738",
            "#f2deb9,739",
            "#fd6f1a,740",
            "#fc8b10,741",
            "#fdae3c,742",
            "#fdd769,743",
            "#fee88d,744",
            "#feeba5,745",
            "#faf2d5,746",
            "#cee9ea,747",
            "#f7c9b0,754",
            "#e99f83,758",
            "#ec8880,760",
            "#f8b4ad,761",
            "#d1d0d2,762",
            "#d7efa7,772",
            "#d4e3ef,775",
            "#9b0042,777",
            "#dca6a4,778",
            "#53332d,779",
            "#945026,780",
            "#b26923,782",
            "#d0883d,783",
            "#2d2068,791",
            "#454b8b,792",
            "#7c82b5,793",
            "#a0b2d7,794",
            "#272276,796",
            "#2b3288,797",
            "#4e5ca7,798",
            "#6b7fc0,799",
            "#b5c7e9,800",
            "#60391d,801",
            "#202754,803",
            "#558b9e,807",
            "#919fd5,809",
            "#7fa0c6,813",
            "#711033,814",
            "#800b34,815",
            "#921238,816",
            "#bb1630,817",
            "#fededd,818",
            "#fcebde,819",
            "#151264,820",
            "#e8dfc7,822",
            "#000b44,823",
            "#284779,824",
            "#34588f,825",
            "#5075a7,826",
            "#a4c1de,827",
            "#c3d7e6,828",
            "#64480c,829",
            "#6e501d,830",
            "#7c5f20,831",
            "#9c7230,832",
            "#b99956,833",
            "#d2b468,834",
            "#4a3021,838",
            "#5a3c2d,839",
            "#7a5939,840",
            "#a37d64,841",
            "#cbb094,842",
            "#494842,844",
            "#784c28,869",
            "#324233,890",
            "#ee3246,891",
            "#f44753,892",
            "#f66879,893",
            "#fd95a3,894",
            "#344b2e,895",
            "#532f1b,898",
            "#ea6b78,899",
            "#c63117,900",
            "#651329,902",
            "#386324,904",
            "#467924,905",
            "#6c9e29,906",
            "#9dc72d,907",
            "#106b43,909",
            "#10814e,910",
            "#109256,911",
            "#36b26b,912",
            "#55ca7d,913",
            "#95085a,915",
            "#ac1071,917",
            "#883630,918",
            "#9b371b,919",
            "#ab4836,920",
            "#c0573d,921",
            "#dd6e4c,922",
            "#384a4a,924",
            "#617674,926",
            "#9fa8a5,927",
            "#c0c6c0,928",
            "#495c6b,930",
            "#667684,931",
            "#93a0af,932",
            "#323324,934",
            "#383a2a,935",
            "#3f4227,936",
            "#434f2c,937",
            "#45271a,938",
            "#09092f,939",
            "#009a77,943",
            "#f6c19a,945",
            "#ed4115,946",
            "#fc4f16,947",
            "#fde6d3,948",
            "#e5ac8d,950",
            "#faddb6,951",
            "#6fda8a,954",
            "#a8ebad,955",
            "#f7566d,956",
            "#fd99af,957",
            "#0db294,958",
            "#72d0b7,959",
            "#de586c,961",
            "#eb7183,962",
            "#fdccd1,963",
            "#a5e4d4,964",
            "#94d28a,966",
            "#ffc2ac,967",
            "#fb6721,970",
            "#fb9f11,972",
            "#fccd2d,973",
            "#813c11,975",
            "#cf7532,976",
            "#ec8f43,977",
            "#2e5230,986",
            "#436838,987",
            "#66924a,988",
            "#71a74e,989",
            "#135f55,991",
            "#42b59e,992",
            "#62d8b6,993",
            "#0061b0,995",
            "#49a8eb,996",
            "#fcfcff,B5200",
            "#eeeeee,Blanc",
            "#fff7e7, Ecru"});
            this.dmcPaletteBox.Location = new System.Drawing.Point(12, 25);
            this.dmcPaletteBox.Name = "dmcPaletteBox";
            this.dmcPaletteBox.Size = new System.Drawing.Size(120, 259);
            this.dmcPaletteBox.TabIndex = 3;
            this.dmcPaletteBox.SelectedIndexChanged += new System.EventHandler(this.dmcPaletteBox_SelectedIndexChanged);
            // 
            // paletteCount
            // 
            this.paletteCount.AutoSize = true;
            this.paletteCount.Location = new System.Drawing.Point(138, 258);
            this.paletteCount.Name = "paletteCount";
            this.paletteCount.Size = new System.Drawing.Size(71, 26);
            this.paletteCount.TabIndex = 4;
            this.paletteCount.Text = "Palette Count\r\n0 / 447\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Select DMC Colours";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(164, 180);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(75, 23);
            this.ConvertButton.TabIndex = 6;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 298);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.paletteCount);
            this.Controls.Add(this.dmcPaletteBox);
            this.Controls.Add(this.ImageTitleText);
            this.Controls.Add(this.UserImageBox);
            this.Controls.Add(this.LoadImageButon);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "DMC Converter";
            ((System.ComponentModel.ISupportInitialize)(this.UserImageBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadImageButon;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox UserImageBox;
        private System.Windows.Forms.Label ImageTitleText;
        private System.Windows.Forms.CheckedListBox dmcPaletteBox;
        private System.Windows.Forms.Label paletteCount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ConvertButton;
    }
}

