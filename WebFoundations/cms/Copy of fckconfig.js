FCKConfig.AutoDetectLanguage = false;
FCKConfig.DefaultLanguage = 'en';
FCKConfig.EditorAreaCSS = FCKConfig.BasePath + '../../static/css/edit.css';
FCKConfig.StylesXmlPath = FCKConfig.BasePath + '../../cms/fckstyles.xml';
FCKConfig.TemplatesXmlPath = FCKConfig.BasePath + '../../cms/FCKTemplates.xml';

//FCKConfig.ToolbarComboPreviewCSS = '';
//FCKConfig.SkinPath = FCKConfig.BasePath + 'skins/default/';
//FCKConfig.PreloadImages = [FCKConfig.SkinPath + 'images/toolbar.start.gif', FCKConfig.SkinPath + 'images/toolbar.buttonarrow.gif'];
// FCKConfig.Plugins.Add( 'autogrow' ) ;
//FCKConfig.AutoGrowMax = 400;

FCKConfig.FormatSource = false;
FCKConfig.FormatOutput = false;
FCKConfig.ProcessHTMLEntities = false;

FCKConfig.ProtectedTags = '';

FCKConfig.ProtectedSource.Add(/<object[\s|\S]+?<\/object>/gi);
FCKConfig.ProtectedSource.Add(/<embed[\s|\S]+?<\/embed>/gi);

FCKConfig.ForcePasteAsPlainText = true;
FCKConfig.AutoDetectPasteFromWord = true; // IE only.
FCKConfig.ShowBorders = true;
FCKConfig.IgnoreEmptyParagraphValue = false;

FCKConfig.ToolbarLocation = 'In';

FCKConfig.ToolbarSets["Default"] = [
	['FitWindow', '-', 'PasteText', '-', 'Style', 'Bold', 'Italic', 'Subscript', 'Superscript', 'SpecialChar', '-', 'OrderedList', 'UnorderedList', '-', 'Link', 'Unlink', '-', 'Image', 'Table', '-', 'SpellCheck', 'Undo', 'Find', '-', 'Templates', 'Source']
];
//FCKConfig.ToolbarSets["Full"] = [
//	['Source', 'DocProps', '-', 'Save', 'NewPage', 'Preview', '-', 'Templates'],
//	['Cut', 'Copy', 'Paste', 'PasteText', 'PasteWord', '-', 'Print', 'SpellCheck'],
//	['Undo', 'Redo', '-', 'Find', 'Replace', '-', 'SelectAll', 'RemoveFormat'],
//	['Form', 'Checkbox', 'Radio', 'TextField', 'Textarea', 'Select', 'Button', 'ImageButton', 'HiddenField'],
//	'/',
//	['Bold', 'Italic', 'Underline', 'StrikeThrough', '-', 'Subscript', 'Superscript'],
//	['OrderedList', 'UnorderedList', '-', 'Outdent', 'Indent'],
//	['JustifyLeft', 'JustifyCenter', 'JustifyRight', 'JustifyFull'],
//	['Link', 'Unlink', 'Anchor'],
//	['Image', 'Flash', 'Table', 'Rule', 'Smiley', 'SpecialChar', 'PageBreak'],
//	'/',
//	['Style', 'FontFormat', 'FontName', 'FontSize'],
//	['TextColor', 'BGColor'],
//	['FitWindow', '-', 'About']
//];

//FCKConfig.ToolbarSets["BasicImage"] = [
//	['Image', 'Bold', 'Italic', '-', 'OrderedList', 'UnorderedList', '-', 'Link', 'Unlink', '-', 'Source']
//];

//FCKConfig.ToolbarSets["Basic"] = [
//	['Bold', 'Italic', '-', 'OrderedList', 'UnorderedList', '-', 'Link', 'Unlink', '-', 'Source']
//];

FCKConfig.ToolbarSets["Minimal"] = [
	['FontFormat', 'Bold', 'Italic', '-', 'OrderedList', 'UnorderedList', '-', 'Link', 'Unlink', '-', 'Subscript', 'Superscript', '-', 'Image', 'Table', 'Rule', '-', 'Source']
];

FCKConfig.EnterMode = 'p'; 		// p | div | br
FCKConfig.ShiftEnterMode = 'br'; // p | div | br

FCKConfig.SpellChecker = 'ieSpell'; // 'ieSpell' | 'SpellerPages'
FCKConfig.IeSpellDownloadUrl = 'http://wcarchive.cdrom.com/pub/simtelnet/handheld/webbrow1/ieSpellSetup240428.exe';
FCKConfig.SpellerPagesServerScript = 'server-scripts/spellchecker.php'; // Available extension: .php .cfm .pl

// Custom implementations should just ignore it.
var _FileBrowserLanguage = 'aspx'; // asp | aspx | cfm | lasso | perl | php | py
var _QuickUploadLanguage = 'aspx'; // asp | aspx | cfm | lasso | php

// Don't care about the following line. It just calculates the correct connector 
// extension to use for the default File Browser (Perl uses "cgi").
var _FileBrowserExtension = _FileBrowserLanguage == 'perl' ? 'cgi' : _FileBrowserLanguage;

FCKConfig.LinkBrowser = true;
FCKConfig.LinkBrowserURL = FCKConfig.BasePath + 'filemanager/browser/default/browser.html?Connector=connectors/' + _FileBrowserLanguage + '/connector.' + _FileBrowserExtension;
FCKConfig.LinkBrowserWindowWidth = FCKConfig.ScreenWidth * 0.7; 	// 70%
FCKConfig.LinkBrowserWindowHeight = FCKConfig.ScreenHeight * 0.7; // 70%

FCKConfig.FlashBrowser = true;
FCKConfig.FlashBrowserURL = FCKConfig.BasePath + 'filemanager/browser/default/browser.html?Type=Flash&Connector=connectors/' + _FileBrowserLanguage + '/connector.' + _FileBrowserExtension;
FCKConfig.FlashBrowserWindowWidth = FCKConfig.ScreenWidth * 0.7; //70% ;
FCKConfig.FlashBrowserWindowHeight = FCKConfig.ScreenHeight * 0.7; //70% ;

FCKConfig.LinkUpload = true;
FCKConfig.LinkUploadURL = FCKConfig.BasePath + 'filemanager/upload/' + _QuickUploadLanguage + '/upload.' + _QuickUploadLanguage;
FCKConfig.LinkUploadAllowedExtensions = ""; 		// empty for all
FCKConfig.LinkUploadDeniedExtensions = ".(html|htm|php|php2|php3|php4|php5|phtml|pwml|inc|asp|aspx|ascx|jsp|cfm|cfc|pl|bat|exe|com|dll|vbs|js|reg|cgi|htaccess|asis)$"; // empty for no one

FCKConfig.ImageUpload = true;
FCKConfig.ImageUploadURL = FCKConfig.BasePath + 'filemanager/upload/' + _QuickUploadLanguage + '/upload.' + _QuickUploadLanguage + '?Type=Image';
FCKConfig.ImageUploadAllowedExtensions = ".(jpg|gif|jpeg|png|bmp)$"; 	// empty for all
FCKConfig.ImageUploadDeniedExtensions = ""; 						// empty for no one

FCKConfig.FlashUpload = true;
FCKConfig.FlashUploadURL = FCKConfig.BasePath + 'filemanager/upload/' + _QuickUploadLanguage + '/upload.' + _QuickUploadLanguage + '?Type=Flash';
FCKConfig.FlashUploadAllowedExtensions = ".(swf|fla)$"; 	// empty for all
FCKConfig.FlashUploadDeniedExtensions = ""; 				// empty for no one

FCKConfig.SmileyPath = FCKConfig.BasePath + 'images/smiley/msn/';
FCKConfig.SmileyImages = ['regular_smile.gif', 'sad_smile.gif', 'wink_smile.gif', 'teeth_smile.gif', 'confused_smile.gif', 'tounge_smile.gif', 'embaressed_smile.gif', 'omg_smile.gif', 'whatchutalkingabout_smile.gif', 'angry_smile.gif', 'angel_smile.gif', 'shades_smile.gif', 'devil_smile.gif', 'cry_smile.gif', 'lightbulb.gif', 'thumbs_down.gif', 'thumbs_up.gif', 'heart.gif', 'broken_heart.gif', 'kiss.gif', 'envelope.gif'];
FCKConfig.SmileyColumns = 8;
FCKConfig.SmileyWindowWidth = 320;
FCKConfig.SmileyWindowHeight = 240;
