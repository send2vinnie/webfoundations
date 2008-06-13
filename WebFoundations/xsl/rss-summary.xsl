<?xml version="1.0" encoding="ISO-8859-1"?>
<xsl:stylesheet version="1.1" 
xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns:atom="http://www.w3.org/2005/Atom"
>
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
			<xsl:value-of disable-output-escaping="yes" select="atom:summary" />
			</div>
			<div style="padding-top:15px;">
			<xsl:element name="a">
					<xsl:attribute name="href"><xsl:value-of select="link" /></xsl:attribute>
					<xsl:attribute name="class">item</xsl:attribute>
					<xsl:attribute name="target">blog</xsl:attribute>
					full story...
			</xsl:element>
			</div>
		</div>
	</xsl:template>
	
</xsl:stylesheet>