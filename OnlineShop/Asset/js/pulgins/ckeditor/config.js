/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
    // config.uiColor = '#AADC6E';
    //config.extraPlugins = 'youtube';
    config.systaxhighlight_lang = "csharp"
    config.systaxhighlight_hideControls = true;
    config.language = 'vi';
    config.filebrowserBrowseUrl = "/Asset/js/pulgins/ckfinder/ckfinder.html";
    config.filebrowserImageUrl = "/Asset/js/pulgins/ckfinder/ckfinder.html?type=Images";
    config.filebrowserFlashUrl = "/Asset/js/pulgins/ckfinder/ckfinder.html?type=Flash";
    config.filebrowserUploadUrl = "/Asset/js/pulgins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files";
    config.filebrowserImageBrowseUrl = "/Data";
    config.filebrowserFlashUploadUrl = "/Asset/js/pulgins/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash";

   
    CKFinder.setupCKEditor(null,'/Asset/js/pulgins/ckfinder/')
};
