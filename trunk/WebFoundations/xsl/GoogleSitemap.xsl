<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.1" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="xml" encoding="UTF-8" />
	<!--
	<xsl:output method="xml" encoding="UTF-8" omit-xml-declaration="yes" />
	-->
	<xsl:param name="ServerName" select="" />
	
	<xsl:template match="/siteMap">
		<urlset xmlns="http://www.google.com/schemas/sitemap/0.84">
			<xsl:call-template name="siteMapNode" />
		</urlset>
	</xsl:template>

	<xsl:template name="siteMapNode">
		<xsl:for-each select="siteMapNode">
		<url xmlns="http://www.google.com/schemas/sitemap/0.84">
		  <loc>http://<xsl:value-of select="$ServerName"/>/<xsl:value-of select="./@url"/></loc>
		  <changefreq>monthly</changefreq>
	   </url>
		<xsl:if test="count(descendant::siteMapNode)>0">
			<xsl:call-template name="siteMapNode" />
		</xsl:if>
		</xsl:for-each>	
	</xsl:template>
	
</xsl:stylesheet>