<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.1" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:output method="html" />
  <xsl:variable name="albumName" select="/album/albumName"/>
  <xsl:variable name="albumItemCount" select="/album/albumItemCount"/>
  
  <xsl:template match="/">
			<div style="margin-bottom:10px; font-weight:bold; ">
				<xsl:value-of select="$albumName"/> (<xsl:value-of select="$albumItemCount"/>)
			</div>
			<xsl:apply-templates select="//image"/>
	</xsl:template>
	
	<xsl:template match="//image">
		<xsl:element name="a">
			<xsl:attribute name="href">Picasa/<xsl:value-of select="$albumName"/>/<xsl:value-of select="itemLargeImage"/></xsl:attribute>
			<xsl:attribute name="rel">lightbox[<xsl:value-of select="$albumName"/>]</xsl:attribute>
			<xsl:element name="img">
				<xsl:attribute name="border">0</xsl:attribute>
				<xsl:attribute name="src">Picasa/<xsl:value-of select="$albumName"/>/<xsl:value-of select="itemThumbnailImage"/></xsl:attribute>
			</xsl:element>
		</xsl:element>
	</xsl:template>
	
</xsl:stylesheet>