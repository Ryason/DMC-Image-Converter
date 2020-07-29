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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LoadImageButon = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.UserImageBox = new System.Windows.Forms.PictureBox();
            this.ImageTitleText = new System.Windows.Forms.Label();
            this.dmcPaletteBox = new System.Windows.Forms.CheckedListBox();
            this.paletteCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.WidthValue = new System.Windows.Forms.NumericUpDown();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.AlgorithmType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.ProgressBarText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.UserImageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadImageButon
            // 
            this.LoadImageButon.Location = new System.Drawing.Point(141, 169);
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
            this.UserImageBox.Location = new System.Drawing.Point(97, 25);
            this.UserImageBox.MaximumSize = new System.Drawing.Size(200, 200);
            this.UserImageBox.MinimumSize = new System.Drawing.Size(120, 120);
            this.UserImageBox.Name = "UserImageBox";
            this.UserImageBox.Size = new System.Drawing.Size(175, 138);
            this.UserImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.UserImageBox.TabIndex = 1;
            this.UserImageBox.TabStop = false;
            // 
            // ImageTitleText
            // 
            this.ImageTitleText.AutoSize = true;
            this.ImageTitleText.Location = new System.Drawing.Point(100, 9);
            this.ImageTitleText.Name = "ImageTitleText";
            this.ImageTitleText.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ImageTitleText.Size = new System.Drawing.Size(92, 13);
            this.ImageTitleText.TabIndex = 2;
            this.ImageTitleText.Text = "Image To Convert";
            this.ImageTitleText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dmcPaletteBox
            // 
            this.dmcPaletteBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dmcPaletteBox.BackColor = System.Drawing.Color.White;
            this.dmcPaletteBox.CheckOnClick = true;
            this.dmcPaletteBox.FormattingEnabled = true;
            this.dmcPaletteBox.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.dmcPaletteBox.Items.AddRange(new object[] {
            "150\t\t171\t2\t73",
            "151\t\t240\t206\t212",
            "152\t\t226\t160\t153",
            "153\t\t230\t204\t217",
            "154\t\t87\t36\t51",
            "155\t\t152\t145\t182",
            "156\t\t163\t174\t209",
            "157\t\t187\t195\t217",
            "158\t\t76\t82\t110",
            "159\t\t199\t202\t215",
            "160\t\t153\t159\t183",
            "161\t\t120\t128\t164",
            "162\t\t219\t236\t245",
            "163\t\t77\t131\t97",
            "164\t\t200\t216\t184",
            "165\t\t239\t244\t164",
            "166\t\t192\t200\t64",
            "167\t\t167\t124\t73",
            "168\t\t209\t209\t209",
            "169\t\t132\t132\t132",
            "208\t\t131\t91\t139",
            "209\t\t163\t123\t167",
            "210\t\t195\t159\t195",
            "211\t\t227\t203\t227",
            "221\t\t136\t62\t67",
            "223\t\t204\t132\t124",
            "224\t\t235\t183\t175",
            "225\t\t255\t223\t213",
            "300\t\t111\t47\t0",
            "301\t\t179\t95\t43",
            "304\t\t183\t31\t51",
            "307\t\t253\t237\t84",
            "309\t\t86\t74\t74",
            "310\t\t0\t0\t0",
            "311\t\t28\t80\t102",
            "312\t\t53\t102\t139",
            "315\t\t129\t73\t82",
            "316\t\t183\t115\t127",
            "317\t\t108\t108\t108",
            "318\t\t171\t171\t171",
            "319\t\t32\t95\t46",
            "320\t\t105\t136\t90",
            "321\t\t199\t43\t59",
            "322\t\t90\t143\t184",
            "326\t\t179\t59\t75",
            "327\t\t99\t54\t102",
            "333\t\t92\t84\t120",
            "334\t\t115\t159\t193",
            "335\t\t238\t84\t110",
            "336\t\t37\t59\t115",
            "340\t\t173\t167\t199",
            "341\t\t183\t191\t221",
            "347\t\t191\t45\t45",
            "349\t\t210\t16\t53",
            "350\t\t224\t72\t72",
            "351\t\t233\t106\t103",
            "352\t\t253\t156\t151",
            "353\t\t254\t215\t204",
            "355\t\t152\t68\t54",
            "356\t\t197\t106\t91",
            "367\t\t97\t122\t82",
            "368\t\t166\t194\t152",
            "369\t\t215\t237\t204",
            "370\t\t184\t157\t100",
            "371\t\t191\t166\t113",
            "372\t\t204\t183\t132",
            "400\t\t143\t67\t15",
            "402\t\t247\t167\t119",
            "407\t\t187\t129\t97",
            "413\t\t86\t86\t86",
            "414\t\t140\t140\t140",
            "415\t\t211\t211\t214",
            "420\t\t160\t112\t66",
            "422\t\t198\t159\t123",
            "433\t\t122\t69\t31",
            "434\t\t152\t94\t51",
            "435\t\t184\t119\t72",
            "436\t\t203\t144\t81",
            "437\t\t228\t187\t142",
            "444\t\t255\t214\t0",
            "445\t\t255\t251\t139",
            "451\t\t145\t123\t115",
            "452\t\t192\t179\t174",
            "453\t\t215\t206\t203",
            "469\t\t114\t132\t60",
            "470\t\t148\t171\t79",
            "471\t\t174\t191\t121",
            "472\t\t216\t228\t152",
            "498\t\t167\t19\t43",
            "500\t\t4\t77\t51",
            "501\t\t57\t111\t82",
            "502\t\t91\t144\t113",
            "503\t\t123\t172\t148",
            "504\t\t196\t222\t204",
            "505\t\t51\t131\t98",
            "517\t\t59\t118\t143",
            "518\t\t79\t147\t167",
            "519\t\t126\t177\t200",
            "520\t\t102\t109\t79",
            "522\t\t150\t158\t126",
            "523\t\t171\t177\t151",
            "524\t\t196\t205\t172",
            "535\t\t99\t100\t88",
            "543\t\t242\t227\t206",
            "550\t\t92\t24\t78",
            "552\t\t128\t58\t107",
            "553\t\t163\t99\t139",
            "554\t\t219\t179\t203",
            "561\t\t44\t106\t69",
            "562\t\t83\t151\t106",
            "563\t\t143\t192\t152",
            "564\t\t167\t205\t175",
            "580\t\t136\t141\t51",
            "581\t\t167\t174\t56",
            "597\t\t91\t163\t179",
            "598\t\t144\t195\t204",
            "600\t\t205\t47\t99",
            "601\t\t209\t40\t106",
            "602\t\t226\t72\t116",
            "603\t\t255\t164\t190",
            "604\t\t255\t176\t190",
            "605\t\t255\t192\t205",
            "606\t\t250\t50\t3",
            "608\t\t253\t93\t53",
            "610\t\t121\t96\t71",
            "611\t\t150\t118\t86",
            "612\t\t188\t154\t120",
            "613\t\t220\t196\t170",
            "632\t\t135\t85\t57",
            "640\t\t133\t123\t97",
            "642\t\t164\t152\t120",
            "644\t\t221\t216\t203",
            "645\t\t110\t101\t92",
            "646\t\t135\t125\t115",
            "647\t\t176\t166\t156",
            "648\t\t188\t180\t172",
            "666\t\t227\t29\t66",
            "676\t\t229\t206\t151",
            "677\t\t245\t236\t203",
            "680\t\t188\t141\t14",
            "699\t\t5\t101\t23",
            "700\t\t7\t115\t27",
            "701\t\t63\t143\t41",
            "702\t\t71\t167\t47",
            "703\t\t123\t181\t71",
            "704\t\t158\t207\t52",
            "712\t\t255\t251\t239",
            "718\t\t156\t36\t98",
            "720\t\t229\t92\t31",
            "721\t\t242\t120\t66",
            "722\t\t247\t151\t111",
            "725\t\t255\t200\t64",
            "726\t\t253\t215\t85",
            "727\t\t255\t241\t175",
            "728\t\t228\t180\t104",
            "729\t\t208\t165\t62",
            "730\t\t130\t123\t48",
            "731\t\t147\t139\t55",
            "732\t\t148\t140\t54",
            "733\t\t188\t179\t76",
            "734\t\t199\t192\t119",
            "738\t\t236\t204\t158",
            "739\t\t248\t228\t200",
            "740\t\t255\t139\t0",
            "741\t\t255\t163\t43",
            "742\t\t255\t191\t87",
            "743\t\t254\t211\t118",
            "744\t\t255\t231\t147",
            "745\t\t255\t233\t173",
            "746\t\t252\t252\t238",
            "747\t\t229\t252\t253",
            "754\t\t247\t203\t191",
            "758\t\t238\t170\t155",
            "760\t\t245\t173\t173",
            "761\t\t255\t201\t201",
            "762\t\t236\t236\t236",
            "772\t\t228\t236\t212",
            "775\t\t217\t235\t241",
            "776\t\t252\t176\t185",
            "777\t\t145\t53\t70",
            "778\t\t223\t179\t187",
            "779\t\t98\t75\t69",
            "780\t\t148\t99\t26",
            "781\t\t162\t109\t32",
            "782\t\t174\t119\t32",
            "783\t\t206\t145\t36",
            "791\t\t70\t69\t99",
            "792\t\t85\t91\t123",
            "793\t\t112\t125\t162",
            "794\t\t143\t156\t193",
            "796\t\t17\t65\t109",
            "797\t\t19\t71\t125",
            "798\t\t70\t106\t142",
            "799\t\t116\t142\t182",
            "800\t\t192\t204\t222",
            "801\t\t101\t57\t25",
            "803\t\t44\t89\t124",
            "806\t\t61\t149\t165",
            "807\t\t100\t171\t186",
            "809\t\t148\t168\t198",
            "813\t\t161\t194\t215",
            "814\t\t123\t0\t27",
            "815\t\t135\t7\t31",
            "816\t\t151\t11\t35",
            "817\t\t187\t5\t31",
            "818\t\t255\t223\t217",
            "819\t\t255\t238\t235",
            "820\t\t14\t54\t92",
            "822\t\t231\t226\t211",
            "823\t\t33\t48\t99",
            "824\t\t57\t105\t135",
            "825\t\t71\t129\t165",
            "826\t\t107\t158\t191",
            "827\t\t189\t221\t237",
            "828\t\t197\t232\t237",
            "829\t\t126\t107\t66",
            "830\t\t141\t120\t75",
            "831\t\t170\t143\t86",
            "832\t\t189\t155\t81",
            "833\t\t200\t171\t108",
            "834\t\t219\t190\t127",
            "838\t\t89\t73\t55",
            "839\t\t103\t85\t65",
            "840\t\t154\t124\t92",
            "841\t\t182\t155\t126",
            "842\t\t209\t186\t161",
            "844\t\t72\t72\t72",
            "869\t\t131\t94\t57",
            "890\t\t23\t73\t35",
            "891\t\t255\t87\t115",
            "892\t\t255\t121\t140",
            "893\t\t252\t144\t162",
            "894\t\t255\t178\t187",
            "895\t\t27\t83\t0",
            "898\t\t73\t42\t19",
            "899\t\t242\t118\t136",
            "900\t\t209\t88\t7",
            "902\t\t130\t38\t55",
            "904\t\t85\t120\t34",
            "905\t\t98\t138\t40",
            "906\t\t127\t179\t53",
            "907\t\t199\t230\t102",
            "909\t\t21\t111\t73",
            "910\t\t24\t126\t86",
            "911\t\t24\t144\t101",
            "912\t\t27\t157\t107",
            "913\t\t109\t171\t119",
            "915\t\t130\t0\t67",
            "917\t\t155\t19\t89",
            "918\t\t130\t52\t10",
            "919\t\t166\t69\t16",
            "920\t\t172\t84\t20",
            "921\t\t198\t98\t24",
            "922\t\t226\t115\t35",
            "924\t\t86\t106\t106",
            "926\t\t152\t174\t174",
            "927\t\t189\t203\t203",
            "928\t\t221\t227\t227",
            "930\t\t69\t92\t113",
            "931\t\t106\t133\t158",
            "932\t\t162\t181\t198",
            "934\t\t49\t57\t25",
            "935\t\t66\t77\t33",
            "936\t\t76\t88\t38",
            "937\t\t98\t113\t51",
            "938\t\t54\t31\t14",
            "939\t\t27\t40\t83",
            "943\t\t61\t147\t132",
            "945\t\t251\t213\t187",
            "946\t\t235\t99\t7",
            "947\t\t255\t123\t77",
            "948\t\t254\t231\t218",
            "950\t\t238\t211\t196",
            "951\t\t255\t226\t207",
            "954\t\t136\t186\t145",
            "955\t\t162\t214\t173",
            "956\t\t255\t145\t145",
            "957\t\t253\t181\t181",
            "958\t\t62\t182\t161",
            "959\t\t89\t199\t180",
            "961\t\t207\t115\t115",
            "962\t\t230\t138\t138",
            "963\t\t255\t215\t215",
            "964\t\t169\t226\t216",
            "966\t\t185\t215\t192",
            "967\t\t255\t222\t213",
            "970\t\t247\t139\t19",
            "971\t\t246\t127\t0",
            "972\t\t255\t181\t21",
            "973\t\t255\t227\t0",
            "975\t\t145\t79\t18",
            "976\t\t194\t129\t66",
            "977\t\t220\t156\t86",
            "986\t\t64\t82\t48",
            "987\t\t88\t113\t65",
            "988\t\t115\t139\t91",
            "989\t\t141\t166\t117",
            "991\t\t71\t123\t110",
            "992\t\t111\t174\t159",
            "993\t\t144\t192\t180",
            "995\t\t38\t150\t182",
            "996\t\t48\t194\t236",
            "3011\t\t137\t138\t88",
            "3012\t\t166\t167\t93",
            "3013\t\t185\t185\t130",
            "3021\t\t79\t75\t65",
            "3022\t\t142\t144\t120",
            "3023\t\t177\t170\t151",
            "3024\t\t235\t234\t231",
            "3031\t\t75\t60\t42",
            "3032\t\t179\t159\t139",
            "3033\t\t227\t216\t204",
            "3041\t\t149\t111\t124",
            "3042\t\t183\t157\t167",
            "3045\t\t188\t150\t106",
            "3046\t\t216\t188\t154",
            "3047\t\t231\t214\t193",
            "3051\t\t95\t102\t72",
            "3052\t\t136\t146\t104",
            "3053\t\t156\t164\t130",
            "3064\t\t196\t142\t112",
            "3072\t\t230\t232\t232",
            "3078\t\t253\t249\t205",
            "3325\t\t184\t210\t230",
            "3326\t\t251\t173\t180",
            "3328\t\t227\t109\t109",
            "3340\t\t255\t131\t111",
            "3341\t\t252\t171\t152",
            "3345\t\t27\t89\t21",
            "3346\t\t64\t106\t58",
            "3347\t\t113\t147\t92",
            "3348\t\t204\t217\t177",
            "3350\t\t188\t67\t101",
            "3354\t\t228\t166\t172",
            "3362\t\t94\t107\t71",
            "3363\t\t114\t130\t86",
            "3364\t\t131\t151\t95",
            "3371\t\t30\t17\t8",
            "3607\t\t197\t73\t137",
            "3608\t\t234\t156\t196",
            "3609\t\t244\t174\t213",
            "3685\t\t136\t21\t49",
            "3687\t\t201\t107\t112",
            "3688\t\t231\t169\t172",
            "3689\t\t251\t191\t194",
            "3705\t\t255\t121\t146",
            "3706\t\t255\t173\t188",
            "3708\t\t255\t203\t213",
            "3712\t\t241\t135\t135",
            "3713\t\t255\t226\t226",
            "3716\t\t255\t189\t189",
            "3721\t\t161\t75\t81",
            "3722\t\t188\t108\t100",
            "3726\t\t155\t91\t102",
            "3727\t\t219\t169\t178",
            "3731\t\t218\t103\t131",
            "3733\t\t232\t135\t155",
            "3740\t\t120\t87\t98",
            "3743\t\t215\t203\t211",
            "3746\t\t119\t107\t152",
            "3747\t\t211\t215\t237",
            "3750\t\t56\t76\t94",
            "3752\t\t199\t209\t219",
            "3753\t\t219\t226\t233",
            "3755\t\t147\t180\t206",
            "3756\t\t238\t252\t252",
            "3760\t\t62\t133\t162",
            "3761\t\t172\t216\t226",
            "3765\t\t52\t127\t140",
            "3766\t\t153\t207\t217",
            "3768\t\t101\t127\t127",
            "3770\t\t255\t238\t227",
            "3771\t\t244\t187\t169",
            "3772\t\t160\t108\t80",
            "3773\t\t182\t117\t82",
            "3774\t\t243\t225\t215",
            "3776\t\t207\t121\t57",
            "3777\t\t134\t48\t34",
            "3778\t\t217\t137\t120",
            "3779\t\t248\t202\t200",
            "3781\t\t107\t87\t67",
            "3782\t\t210\t188\t166",
            "3787\t\t98\t93\t80",
            "3790\t\t127\t106\t85",
            "3799\t\t66\t66\t66",
            "3801\t\t231\t73\t103",
            "3802\t\t113\t65\t73",
            "3803\t\t171\t51\t87",
            "3804\t\t224\t40\t118",
            "3805\t\t243\t71\t139",
            "3806\t\t255\t140\t174",
            "3807\t\t96\t103\t140",
            "3808\t\t54\t105\t112",
            "3809\t\t63\t124\t133",
            "3810\t\t72\t142\t154",
            "3811\t\t188\t227\t230",
            "3812\t\t47\t140\t132",
            "3813\t\t178\t212\t189",
            "3814\t\t80\t139\t125",
            "3815\t\t71\t119\t89",
            "3816\t\t101\t165\t125",
            "3817\t\t153\t195\t170",
            "3818\t\t17\t90\t59",
            "3819\t\t224\t232\t104",
            "3820\t\t223\t182\t95",
            "3821\t\t243\t206\t117",
            "3822\t\t246\t220\t152",
            "3823\t\t255\t253\t227",
            "3824\t\t254\t205\t194",
            "3825\t\t253\t189\t150",
            "3826\t\t173\t114\t57",
            "3827\t\t247\t187\t119",
            "3828\t\t183\t139\t97",
            "3829\t\t169\t130\t4",
            "3830\t\t185\t85\t68",
            "3831\t\t179\t47\t72",
            "3832\t\t219\t85\t110",
            "3833\t\t234\t134\t153",
            "3834\t\t114\t55\t93",
            "3835\t\t148\t96\t131",
            "3836\t\t186\t145\t170",
            "3837\t\t108\t58\t110",
            "3838\t\t92\t114\t148",
            "3839\t\t123\t142\t171",
            "3840\t\t176\t192\t218",
            "3841\t\t205\t223\t237",
            "3842\t\t50\t102\t124",
            "3843\t\t20\t170\t208",
            "3844\t\t18\t174\t186",
            "3845\t\t4\t196\t202",
            "3846\t\t6\t227\t230",
            "3847\t\t52\t125\t117",
            "3848\t\t85\t147\t146",
            "3849\t\t82\t179\t164",
            "3850\t\t55\t132\t119",
            "3851\t\t73\t179\t161",
            "3852\t\t205\t157\t55",
            "3853\t\t242\t151\t70",
            "3854\t\t242\t175\t104",
            "3855\t\t250\t211\t150",
            "3856\t\t255\t211\t181",
            "3857\t\t104\t37\t26",
            "3858\t\t150\t74\t63",
            "3859\t\t186\t139\t124",
            "3860\t\t125\t93\t87",
            "3861\t\t166\t136\t129",
            "3862\t\t138\t110\t78",
            "3863\t\t164\t131\t92",
            "3864\t\t203\t182\t156",
            "3865\t\t249\t247\t241",
            "3866\t\t250\t246\t240",
            "B5200\t\t255\t255\t255",
            "Ecru\t\t240\t234\t218",
            "White\t\t252\t251\t248"});
            this.dmcPaletteBox.Location = new System.Drawing.Point(12, 25);
            this.dmcPaletteBox.Name = "dmcPaletteBox";
            this.dmcPaletteBox.Size = new System.Drawing.Size(82, 679);
            this.dmcPaletteBox.TabIndex = 3;
            this.dmcPaletteBox.SelectedIndexChanged += new System.EventHandler(this.dmcPaletteBox_SelectedIndexChanged);
            // 
            // paletteCount
            // 
            this.paletteCount.AutoSize = true;
            this.paletteCount.Location = new System.Drawing.Point(100, 667);
            this.paletteCount.Name = "paletteCount";
            this.paletteCount.Size = new System.Drawing.Size(71, 26);
            this.paletteCount.TabIndex = 4;
            this.paletteCount.Text = "Palette Count\r\n0 / 447\r\n";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "DMC Colours";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(141, 370);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(75, 23);
            this.ConvertButton.TabIndex = 6;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // WidthValue
            // 
            this.WidthValue.Location = new System.Drawing.Point(129, 11);
            this.WidthValue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.WidthValue.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthValue.Name = "WidthValue";
            this.WidthValue.Size = new System.Drawing.Size(43, 20);
            this.WidthValue.TabIndex = 7;
            this.WidthValue.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.WidthValue.ValueChanged += new System.EventHandler(this.WidthValue_ValueChanged);
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(3, 13);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(35, 13);
            this.WidthLabel.TabIndex = 8;
            this.WidthLabel.Text = "Width";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Enabled = false;
            this.numericUpDown1.Location = new System.Drawing.Point(129, 37);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(43, 20);
            this.numericUpDown1.TabIndex = 9;
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(3, 39);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(38, 13);
            this.HeightLabel.TabIndex = 10;
            this.HeightLabel.Text = "Height";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(142, 399);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(74, 13);
            this.progressBar.TabIndex = 11;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.dataGridView1.Location = new System.Drawing.Point(97, 454);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.MenuText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.MenuText;
            this.dataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Size = new System.Drawing.Size(175, 148);
            this.dataGridView1.TabIndex = 12;
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // AlgorithmType
            // 
            this.AlgorithmType.FormattingEnabled = true;
            this.AlgorithmType.Items.AddRange(new object[] {
            "CIE76",
            "CIE94",
            "CMC l:C",
            "CIE2000"});
            this.AlgorithmType.Location = new System.Drawing.Point(106, 115);
            this.AlgorithmType.Name = "AlgorithmType";
            this.AlgorithmType.Size = new System.Drawing.Size(65, 21);
            this.AlgorithmType.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Matching Algorithm";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(129, 89);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(42, 20);
            this.numericUpDown2.TabIndex = 16;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Auto Matched Threads";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(435, 301);
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseClick);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(278, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(813, 682);
            this.panel1.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Grid Size";
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(129, 63);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(42, 20);
            this.numericUpDown3.TabIndex = 21;
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.WidthLabel);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.numericUpDown3);
            this.panel2.Controls.Add(this.AlgorithmType);
            this.panel2.Controls.Add(this.WidthValue);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.numericUpDown1);
            this.panel2.Controls.Add(this.HeightLabel);
            this.panel2.Controls.Add(this.numericUpDown2);
            this.panel2.Location = new System.Drawing.Point(97, 198);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(175, 166);
            this.panel2.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 623);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "grid position";
            // 
            // ProgressBarText
            // 
            this.ProgressBarText.Location = new System.Drawing.Point(97, 415);
            this.ProgressBarText.Name = "ProgressBarText";
            this.ProgressBarText.Size = new System.Drawing.Size(171, 18);
            this.ProgressBarText.TabIndex = 24;
            this.ProgressBarText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 726);
            this.Controls.Add(this.ProgressBarText);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.paletteCount);
            this.Controls.Add(this.dmcPaletteBox);
            this.Controls.Add(this.ImageTitleText);
            this.Controls.Add(this.UserImageBox);
            this.Controls.Add(this.LoadImageButon);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DMC Converter";
            ((System.ComponentModel.ISupportInitialize)(this.UserImageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.NumericUpDown WidthValue;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label HeightLabel;
        public System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox AlgorithmType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ProgressBarText;
    }
}

