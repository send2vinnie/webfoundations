<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.1" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method = "html" encoding="UTF-8" /> 
  <xsl:variable name="title" select="/rss/channel/title"/>
  
	<xsl:template match="/">
		<div>
			<xsl:apply-templates select="rss/channel"/>
		</div>
	</xsl:template>
	
	<xsl:template match="channel">
		<div>
			<xsl:apply-templates select="item"/>
		</div>	
	</xsl:template>
	
	<xsl:template match="item">
		<div id="item">
			<h2><xsl:value-of select="title"/></h2>

			<div>
			<xsl:value-of disable-output-escaping="yes" select="description" />
			</div>

		</div>
	</xsl:template>
	
</xsl:stylesheet>