/**
 * @license Copyright (c) 2003-2016, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here. For example:
	// config.language = 'fr';
	// config.uiColor = '#AADC6E';
   config.filebrowserBrowseUrl = '/Scripts/ckfinder/ckfinder.html';
   config.filebrowserImageBrowseUrl = '/Scripts/ckfinder/ckfinder.html?type=Images';
   config.filebrowserFlashBrowseUrl = '/Scripts/ckfinder/ckfinder.html?type=Flash';
   config.filebrowserUploadUrl = '/Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Files';
   config.filebrowserImageUploadUrl = '/Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Images';
   config.filebrowserFlashUploadUrl = '/Scripts/ckfinder/core/connector/aspx/connector.aspx?command=QuickUpload&type=Flash';
};
