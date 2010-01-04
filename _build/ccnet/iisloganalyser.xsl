<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
   <xsl:output method="html"/>
	
  <xsl:template match="/">
    <xsl:variable name="iisrecords" select="/cruisecontrol/build/ROOT" />
    <xsl:apply-templates select="$iisrecords" />
  </xsl:template>
	
	<xsl:template match="ROOT">
		<xsl:apply-templates />
	</xsl:template>
	
	<xsl:template match="ROW">

    <xsl:choose>
      <xsl:when test="sc-status = 403 or sc-status = 404">
        <p style="color:red">
          <xsl:value-of select="time"/> : <xsl:value-of select="sc-status"/> : <xsl:value-of select="cs-uri-stem"/>
        </p>        
      </xsl:when>
      <xsl:otherwise>
        <p style="color:green">
          <xsl:value-of select="time"/> : <xsl:value-of select="sc-status"/> : <xsl:value-of select="cs-uri-stem"/>
        </p>
      </xsl:otherwise>
    </xsl:choose>
    

	</xsl:template>
	
</xsl:stylesheet>